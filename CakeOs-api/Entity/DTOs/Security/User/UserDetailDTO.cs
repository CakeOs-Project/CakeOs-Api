namespace CakeOS.Entity.DTOs.SecurityDtos.UsuarioDtos;

public class UserDetailDTO
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int PersonaId { get; set; }
    public string PersonaNombre { get; set; } = string.Empty;
    public string PersonaApellido { get; set; } = string.Empty;
    public string PersonaTelefono { get; set; } = string.Empty;
    public string? PersonaDireccion { get; set; }
    public int RolId { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public string RolDescripcion { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
