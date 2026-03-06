namespace CakeOs.Entity.DTOs.Security.FormModuleDtos;

public class FormModuleDetailDTO
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string FormNombre { get; set; } = string.Empty;
    public string FormDescripcion { get; set; } = string.Empty;
    public int ModuleId { get; set; }
    public string ModuloNombre { get; set; } = string.Empty;
    public string ModuloDescripcion { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
