namespace CakeOS.Entity.DTOs.SecurityDtos.AuthDtos;

public class LoginResponseDTO
{
    public int UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public int RolId { get; set; }
    public string RolName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationAt { get; set; }
}
