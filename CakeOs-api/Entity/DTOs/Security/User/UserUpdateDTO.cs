namespace CakeOS.Entity.DTOs.SecurityDtos.UsuarioDtos;

public class UserUpdateDTO
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int PersonaId { get; set; }
    public int RolId { get; set; }
    public bool IsActive { get; set; }
}
