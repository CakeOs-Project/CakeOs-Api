namespace CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

public class PersonDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
