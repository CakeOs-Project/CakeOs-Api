using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

namespace CakeOS.Entity.DTOs.SecurityDtos.UsuarioDtos;

public class UsuarioCreateDTO
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int RolId { get; set; }
    public PersonaCreateDTO Person { get; set; } = new PersonaCreateDTO();
}
