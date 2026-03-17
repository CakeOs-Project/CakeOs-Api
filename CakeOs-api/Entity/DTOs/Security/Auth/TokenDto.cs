namespace CakeOS.Entity.DTOs.Security.Auth
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RolName { get; set; }
        public string FullName { get; set; }
    }
}