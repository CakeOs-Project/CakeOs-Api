namespace CakeOS.Entity.DTOs.SecurityDtos.FormularioModuloDtos;

public class FormularioModuloUpdateDTO
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int ModuleId { get; set; }
    public bool IsActive { get; set; }
}
