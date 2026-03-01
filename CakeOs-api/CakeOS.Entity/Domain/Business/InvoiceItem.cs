using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.CakeEntity;

public class InvoiceItem : BaseEntity
{
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal { get; set; }
    public bool HasFilling { get; set; }
    public int? FilledId { get; set; }
    public bool HasDecoration { get; set; }
    public string? DecorationImage { get; set; }
    public string? DecorationDescription { get; set; }
    public bool HasMessage { get; set; }
    public string? Message { get; set; }

    public Invoice? Invoice { get; set; }
    public Product? Product { get; set; }
    public Filled? Filled { get; set; }
}
