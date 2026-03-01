using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

namespace CakeOS.Entity.DTOs.BusinessDtos.ClienteDtos;

public class ClienteCreateDTO
{
    public PersonaCreateDTO Person { get; set; } = new PersonaCreateDTO();
}
