namespace CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;

public class RolFormPermissionListDTO
{
    public int Id { get; set; }
    public int RolId { get; set; }
    public string RolName { get; set; } = string.Empty;
    public int FormId { get; set; }
    public string FormName { get; set; } = string.Empty;
    public int PermissionId { get; set; }
    public string PermissionName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
