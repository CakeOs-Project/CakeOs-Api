namespace CakeOs.Entity.DTOs.Security.FormModuleDtos;

public class FormModuleUpdateDTO
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int ModuleId { get; set; }
    public bool IsActive { get; set; }
}
