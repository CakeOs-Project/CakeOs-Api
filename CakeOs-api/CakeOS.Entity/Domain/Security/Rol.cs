using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security;

public class Rol : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<RolFormPermission> RolFormPermissions { get; set; } = new List<RolFormPermission>();
}
