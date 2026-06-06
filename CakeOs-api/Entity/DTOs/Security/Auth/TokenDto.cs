namespace CakeOS.Entity.DTOs.Security.Auth
{
    public class TokenDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        public int RolId { get; set; }
        public string RolName { get; set; } = string.Empty;
        public int TenantId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsCompleteInfo { get; set; }
        public List<LoginModuleDto> Modules { get; set; } = new();
    }

    public class LoginModuleDto
    {
        public string ModuleName { get; set; } = string.Empty;
        public List<LoginFormDto> Forms { get; set; } = new();
    }

    public class LoginFormDto
    {
        public string FormName { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new();
    }

    public class TokenInfoDto
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public int RolId { get; set; }
        public string RolName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public bool IsCompleteInfo { get; set; }
        public List<LoginModuleDto> Modules { get; set; } = new();
    }
}