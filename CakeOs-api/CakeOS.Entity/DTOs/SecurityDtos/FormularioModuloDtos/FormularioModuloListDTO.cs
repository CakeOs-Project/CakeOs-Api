namespace CakeOS.Entity.DTOs.SecurityDtos.FormularioModuloDtos;

public class FormularioModuloListDTO
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string FormNombre { get; set; } = string.Empty;
    public int ModuleId { get; set; }
    public string ModuloNombre { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
