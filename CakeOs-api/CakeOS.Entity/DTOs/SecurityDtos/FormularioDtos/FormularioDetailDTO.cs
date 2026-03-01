namespace CakeOS.Entity.DTOs.SecurityDtos.FormularioDtos;

public class FormularioDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
