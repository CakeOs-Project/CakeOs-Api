using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.CakeEntity;
using CakeOs.Entity.Domain.Business;

namespace CakeOs.Entity.Domain.Parameter;

public class Shape : BaseDomain
{
    public string Name { get; set; } = string.Empty;

    ///
    /// Relaciones
    ///
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
