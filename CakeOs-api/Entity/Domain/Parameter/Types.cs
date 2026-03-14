using CakeOs.Entity.Domain.Business;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Entity.Domain.Parameter;

public class Types : BaseDomain
{
    public string Name { get; set; } = string.Empty;
    public bool DefaultFill { get; set; }

    ///
    /// Relaciones
    ///
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
