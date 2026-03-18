using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security
{
    public class Module : BaseAuditory
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<FormModule> FormModules { get; set; } = new List<FormModule>();
    }
}