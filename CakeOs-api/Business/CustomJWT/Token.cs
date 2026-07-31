using CakeOs.Business.Interfaces;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.CustomJWT
{
    public class Token : IToken
    {
        private readonly IConfiguration _configuration;

        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<TokenDto> GenerateTokensAsync(User user, string fullName, string rolName)
        {
            var key = _configuration["Jwt:Key"] ?? "CakeOs.Dev.Jwt.Key.Change.Me.2026";
            var issuer = _configuration["Jwt:Issuer"] ?? "CakeOs";
            var audience = _configuration["Jwt:Audience"] ?? "CakeOs.Client";
            var expireMinutes = int.TryParse(_configuration["Jwt:ExpireMinutes"], out var minutes)
                ? minutes
                : 120;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new("userId", user.Id.ToString()),
                new("tenantId", user.TenantId.ToString()),
                new("rolId", user.RolId.ToString()),
                new(ClaimTypes.Role, rolName ?? string.Empty),
                new("fullName", fullName ?? string.Empty)
            };

            var expiration = DateTime.UtcNow.AddMinutes(expireMinutes);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            return Task.FromResult(new TokenDto
            {
                Token = tokenString,
                RefreshToken = refreshToken,
                Expiration = expiration,
                UserId = user.Id,
                TenantId = user.TenantId,
                RolId = user.RolId,
                RolName = rolName ?? string.Empty,
                FullName = fullName ?? string.Empty,
                Email = user.Email ?? string.Empty
            });
        }
    }
}
