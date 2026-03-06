using CakeOs.Entity.Domain.Parameter;
using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Product : BaseDomain
{
    public int TypeId { get; set; }
    public int SizeId { get; set; }
    public int ShapeId { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }

    ///
    /// Relaciones
    ///
    public Types? Type { get; set; }    
    public Size? Size { get; set; }
    public Shape? Shape { get; set; }
    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
