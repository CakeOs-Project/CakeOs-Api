using CakeOs.Entity.Domain.Base;
using CakeOs.Entity.Domain.Parameter;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.Business;


namespace CakeOs.Entity.Domain.Business;

public class Product : BaseAuditory
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
