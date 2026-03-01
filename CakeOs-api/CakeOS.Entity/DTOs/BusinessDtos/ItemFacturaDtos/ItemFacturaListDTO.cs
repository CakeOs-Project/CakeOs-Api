namespace CakeOS.Entity.DTOs.BusinessDtos.ItemFacturaDtos;

public class ItemFacturaListDTO
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public string ProductoDescripcion { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal { get; set; }
    public bool HasFilling { get; set; }
    public string? RellenoNombre { get; set; }
    public bool IsActive { get; set; }
}
