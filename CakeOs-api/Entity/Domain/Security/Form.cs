using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security
{
    public class Form : BaseAuditory
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public ICollection<FormModule> FormModules { get; set; } = new List<FormModule>();
        public ICollection<RolFormPermission> RolFormPermissions { get; set; } = new List<RolFormPermission>();
    }
}