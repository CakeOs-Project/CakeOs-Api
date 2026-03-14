using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.CakeEntity;
using CakeOs.Entity.Domain.Business;

namespace CakeOs.Entity.Domain.Parameter;

public class Type : BaseDomain
{
    public string Name { get; set; } = string.Empty;
    public bool DefaultFill { get; set; }

    ///
    /// Relaciones
    ///
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
