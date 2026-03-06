using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Entity.Domain.Parameter;

public class Size : BaseDomain
{
    public string Name { get; set; } = string.Empty;

    ///
    /// Relaciones
    ///
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
