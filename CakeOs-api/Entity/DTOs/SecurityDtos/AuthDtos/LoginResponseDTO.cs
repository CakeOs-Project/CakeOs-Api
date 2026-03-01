namespace CakeOS.Entity.DTOs.SecurityDtos.AuthDtos;

public class LoginResponseDTO
{
    public int UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public int RolId { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime FechaExpiracion { get; set; }
}
