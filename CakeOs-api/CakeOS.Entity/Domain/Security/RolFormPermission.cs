using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security;

public class RolFormPermission : BaseEntity
{
    public int RolId { get; set; }
    public int FormId { get; set; }
    public int PermissionId { get; set; }

    public Rol? Rol { get; set; }
    public Form? Form { get; set; }
    public Permission? Permission { get; set; }
}
