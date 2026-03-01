namespace CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;

public class RolFormularioPermisoListDTO
{
    public int Id { get; set; }
    public int RolId { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public int FormId { get; set; }
    public string FormNombre { get; set; } = string.Empty;
    public int PermissionId { get; set; }
    public string PermisoNombre { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
