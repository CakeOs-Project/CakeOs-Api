using CakeOs.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security
{
    public class Permission : BaseAuditory
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<RolFormPermission> RolFormPermissions { get; set; } = new List<RolFormPermission>();
    }
}