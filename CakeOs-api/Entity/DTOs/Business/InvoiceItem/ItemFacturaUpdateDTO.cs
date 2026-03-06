namespace CakeOS.Entity.DTOs.BusinessDtos.ItemFacturaDtos;

public class ItemFacturaUpdateDTO
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool HasFilling { get; set; }
    public int? FilledId { get; set; }
    public bool HasDecoration { get; set; }
    public string? DecorationImage { get; set; }
    public string? DecorationDescription { get; set; }
    public bool HasMessage { get; set; }
    public string? Message { get; set; }
    public bool IsActive { get; set; }
}
