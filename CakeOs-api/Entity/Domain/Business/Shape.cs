using CakeOS.Entity.Domain.Base;

namespace CakeOs.Entity.Domain.Business;

public class Shape : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
