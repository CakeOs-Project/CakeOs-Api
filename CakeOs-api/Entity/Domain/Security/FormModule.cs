using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.security;

public class FormModule : BaseEntity
{
    public int FormId { get; set; }
    public int ModuleId { get; set; }

    public Form? Form { get; set; }
    public Module? Module { get; set; }
}
