namespace CakeOS.Entity.DTOs.BusinessDtos.TamanoDtos;

public class TamanoDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
