namespace CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;

public class RolFormPermissionDetailDTO
{
    public int Id { get; set; }
    public int RolId { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public string RolDescripcion { get; set; } = string.Empty;
    public int FormId { get; set; }
    public string FormNombre { get; set; } = string.Empty;
    public string FormDescripcion { get; set; } = string.Empty;
    public int PermissionId { get; set; }
    public string PermisoNombre { get; set; } = string.Empty;
    public string PermisoDescripcion { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
