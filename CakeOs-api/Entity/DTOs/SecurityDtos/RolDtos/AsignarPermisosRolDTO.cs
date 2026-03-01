namespace CakeOS.Entity.DTOs.SecurityDtos.RolDtos;

public class AsignarPermisosRolDTO
{
    public int RolId { get; set; }
    public int FormId { get; set; }
    public List<int> PermissionIds { get; set; } = new List<int>();
}
