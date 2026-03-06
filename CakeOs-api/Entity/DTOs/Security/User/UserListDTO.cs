namespace CakeOS.Entity.DTOs.SecurityDtos.UsuarioDtos;

public class UserListDTO
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PersonaNombre { get; set; } = string.Empty;
    public string PersonaApellido { get; set; } = string.Empty;
    public string RolNombre { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
