using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security
{
    public class FormModule : BaseAuditory
    {
        public int FormId { get; set; }
        public int ModuleId { get; set; }

        public Form? Form { get; set; }
        public Module? Module { get; set; }
    }
}