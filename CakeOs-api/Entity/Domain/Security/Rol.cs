using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security
{
    public class Rol : BaseAuditory
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<RolFormPermission> RolFormPermissions { get; set; } = new List<RolFormPermission>();
    }
}