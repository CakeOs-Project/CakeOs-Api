namespace CakeOs.Entity.DTOs.Security.FormModuleDtos;

public class FormModuleListDTO
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string FormNombre { get; set; } = string.Empty;
    public int ModuleId { get; set; }
    public string ModuloNombre { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
