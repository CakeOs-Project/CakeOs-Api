using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Type : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool DefaultFill { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
