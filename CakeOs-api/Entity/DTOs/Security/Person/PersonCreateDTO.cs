namespace CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

public class PersonCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; }
}
