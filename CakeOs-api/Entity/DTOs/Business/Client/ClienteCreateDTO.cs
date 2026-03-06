using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

namespace CakeOS.Entity.DTOs.BusinessDtos.ClienteDtos;

public class ClienteCreateDTO
{
    public PersonCreateDTO Person { get; set; } = new PersonCreateDTO();
}
