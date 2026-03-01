using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Product : BaseEntity
{
    public int TypeId { get; set; }
    public int SizeId { get; set; }
    public int ShapeId { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public Type? Type { get; set; }
    public Size? Size { get; set; }
    public Shape? Shape { get; set; }
    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
