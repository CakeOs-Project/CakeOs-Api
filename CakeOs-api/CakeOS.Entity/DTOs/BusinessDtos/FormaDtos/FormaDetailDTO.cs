namespace CakeOS.Entity.DTOs.BusinessDtos.FormaDtos;

public class FormaDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
