namespace CakeOS.Entity.DTOs.BusinessDtos.ClienteDtos;

public class ClienteDetailDTO
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string PersonaNombre { get; set; } = string.Empty;
    public string PersonaApellido { get; set; } = string.Empty;
    public string PersonaTelefono { get; set; } = string.Empty;
    public string? PersonaDireccion { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
