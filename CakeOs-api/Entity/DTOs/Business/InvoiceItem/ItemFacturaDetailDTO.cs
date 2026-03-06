namespace CakeOS.Entity.DTOs.BusinessDtos.ItemFacturaDtos;

public class ItemFacturaDetailDTO
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public string ProductoDescripcion { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal { get; set; }
    public bool HasFilling { get; set; }
    public int? FilledId { get; set; }
    public string? RellenoNombre { get; set; }
    public bool HasDecoration { get; set; }
    public string? DecorationImage { get; set; }
    public string? DecorationDescription { get; set; }
    public bool HasMessage { get; set; }
    public string? Message { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
