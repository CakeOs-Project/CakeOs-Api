using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Size : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
