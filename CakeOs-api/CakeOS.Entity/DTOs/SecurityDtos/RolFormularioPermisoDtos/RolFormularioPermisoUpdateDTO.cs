namespace CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;

public class RolFormularioPermisoUpdateDTO
{
    public int Id { get; set; }
    public int RolId { get; set; }
    public int FormId { get; set; }
    public int PermissionId { get; set; }
    public bool IsActive { get; set; }
}
