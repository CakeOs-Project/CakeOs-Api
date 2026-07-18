using CakeOs.Business.Interfaces;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.DTOs.Security.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CakeOs.Business.Services.Security
{
    public class AuthServices : IAuthServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IRolFormPermissionRepository _rolFormPermissionRepository;
        private readonly IToken _tokenService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthServices> _logger;

        public AuthServices(
            IUserRepository userRepository,
            IRolFormPermissionRepository rolFormPermissionRepository,
            IToken tokenService,
            IConfiguration configuration,
            ILogger<AuthServices> logger)
        {
            _userRepository = userRepository;
            _rolFormPermissionRepository = rolFormPermissionRepository;
            _tokenService = tokenService;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<TokenDto> LoginAsync(LoginDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto), "La informacion de login es requerida.");

            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                throw new UnauthorizedAccessException("Correo o contrasena invalidos.");

            _logger.LogInformation("Intento de login para {Email}", dto.Email);

            var user = await _userRepository.GetByEmailAsync(dto.Email.Trim());

            if (user is null || !user.IsActive || user.IsDeleted)
            {
                _logger.LogWarning("Login fallido — usuario no encontrado o inactivo: {Email}", dto.Email);
                throw new UnauthorizedAccessException("Usuario no encontrado o inactivo.");
            }

            if (!string.Equals(user.Password, dto.Password, StringComparison.Ordinal))
            {
                _logger.LogWarning("Login fallido — contraseña incorrecta para {Email}", dto.Email);
                throw new UnauthorizedAccessException("Correo o contrasena invalidos.");
            }

            var fullName = BuildFullName(user.Person?.Name, user.Person?.LastName);
            var rolName = user.Rol?.Name ?? string.Empty;

            var token = await _tokenService.GenerateTokensAsync(user, fullName, rolName);
            var modules = await BuildModulesAsync(user.RolId);

            token.Modules = modules;
            token.IsCompleteInfo = HasCompleteInfo(token, modules);

            _logger.LogInformation("Login exitoso para {Email} (UserId: {UserId})", dto.Email, user.Id);

            // Fallback minimo: siempre devolver ids clave aunque no exista todo el arbol de permisos.
            if (!token.IsCompleteInfo)
            {
                token.FullName = string.IsNullOrWhiteSpace(token.FullName)
                    ? $"User #{token.UserId}"
                    : token.FullName;
                token.RolName = string.IsNullOrWhiteSpace(token.RolName)
                    ? $"Rol #{token.RolId}"
                    : token.RolName;
            }

            return token;
        }

        public async Task<TokenInfoDto> GetTokenInfoAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new UnauthorizedAccessException("Token requerido.");

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
                throw new UnauthorizedAccessException("Token invalido.");

            var principal = ValidateToken(token);

            var userId = ParseIntClaim(principal, "userId");
            var tenantId = ParseIntClaim(principal, "tenantId");
            var rolId = ParseIntClaim(principal, "rolId");

            var rolName = principal.FindFirstValue("rolName") ?? string.Empty;
            var fullName = principal.FindFirstValue("fullName") ?? string.Empty;
            var email = principal.FindFirstValue(JwtRegisteredClaimNames.Email)
                ?? principal.FindFirstValue(ClaimTypes.Email)
                ?? string.Empty;

            var jwt = handler.ReadJwtToken(token);
            var modules = await BuildModulesAsync(rolId);

            var info = new TokenInfoDto
            {
                UserId = userId,
                TenantId = tenantId,
                RolId = rolId,
                RolName = rolName,
                FullName = fullName,
                Email = email,
                Expiration = jwt.ValidTo,
                Modules = modules
            };

            info.IsCompleteInfo = HasCompleteInfo(info, modules);

            if (!info.IsCompleteInfo)
            {
                info.FullName = string.IsNullOrWhiteSpace(info.FullName)
                    ? $"User #{info.UserId}"
                    : info.FullName;
                info.RolName = string.IsNullOrWhiteSpace(info.RolName)
                    ? $"Rol #{info.RolId}"
                    : info.RolName;
            }

            return info;
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            var key = _configuration["Jwt:Key"] ?? "CakeOs.Dev.Jwt.Key.Change.Me.2026";
            var issuer = _configuration["Jwt:Issuer"] ?? "CakeOs";
            var audience = _configuration["Jwt:Audience"] ?? "CakeOs.Client";

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out _);
        }

        private static int ParseIntClaim(ClaimsPrincipal principal, string claimType)
        {
            var raw = principal.FindFirstValue(claimType);
            return int.TryParse(raw, out var value) ? value : 0;
        }

        private async Task<List<LoginModuleDto>> BuildModulesAsync(int rolId)
        {
            if (rolId <= 0)
                return new List<LoginModuleDto>();

            var rolePermissions = await _rolFormPermissionRepository.GetByRolIdWithModulesAsync(rolId);

            var modules = rolePermissions
                .SelectMany(rfp =>
                {
                    var moduleNames = rfp.Form?.FormModules?
                        .Select(fm => fm.Module?.Name)
                        .Where(name => !string.IsNullOrWhiteSpace(name))
                        .Cast<string>()
                        .Distinct()
                        .ToList() ?? new List<string>();

                    if (moduleNames.Count == 0)
                    {
                        moduleNames.Add("General");
                    }

                    return moduleNames.Select(moduleName => new
                    {
                        ModuleName = moduleName,
                        FormName = rfp.Form?.Name ?? "Form",
                        PermissionName = rfp.Permission?.Name ?? "Read"
                    });
                })
                .GroupBy(x => x.ModuleName)
                .Select(moduleGroup => new LoginModuleDto
                {
                    ModuleName = moduleGroup.Key,
                    Forms = moduleGroup
                        .GroupBy(x => x.FormName)
                        .Select(formGroup => new LoginFormDto
                        {
                            FormName = formGroup.Key,
                            Permissions = formGroup
                                .Select(x => x.PermissionName)
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .Distinct(StringComparer.OrdinalIgnoreCase)
                                .OrderBy(p => p)
                                .ToList()
                        })
                        .OrderBy(f => f.FormName)
                        .ToList()
                })
                .OrderBy(m => m.ModuleName)
                .ToList();

            return modules;
        }

        private static string BuildFullName(string? name, string? lastName)
        {
            var fullName = $"{name} {lastName}".Trim();
            return string.IsNullOrWhiteSpace(fullName) ? string.Empty : fullName;
        }

        private static bool HasCompleteInfo(TokenDto token, List<LoginModuleDto> modules)
        {
            return token.UserId > 0
                && token.TenantId > 0
                && token.RolId > 0
                && !string.IsNullOrWhiteSpace(token.FullName)
                && !string.IsNullOrWhiteSpace(token.RolName)
                && modules.Count > 0;
        }

        private static bool HasCompleteInfo(TokenInfoDto token, List<LoginModuleDto> modules)
        {
            return token.UserId > 0
                && token.TenantId > 0
                && token.RolId > 0
                && !string.IsNullOrWhiteSpace(token.FullName)
                && !string.IsNullOrWhiteSpace(token.RolName)
                && modules.Count > 0;
        }
    }
}
