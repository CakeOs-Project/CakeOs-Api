using CakeOS.Entity.DTOs.BusinessDtos.ItemFacturaDtos;

namespace CakeOS.Entity.DTOs.BusinessDtos.FacturaDtos;

public class FacturaConItemsCreateDTO
{
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public decimal? MontoAnticipo { get; set; }
    public string? MetodoPagoAnticipo { get; set; }
    public List<FacturaItemDTO> Items { get; set; } = new List<FacturaItemDTO>();
}

public class FacturaItemDTO
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool HasFilling { get; set; }
    public int? FilledId { get; set; }
    public bool HasDecoration { get; set; }
    public string? DecorationImage { get; set; }
    public string? DecorationDescription { get; set; }
    public bool HasMessage { get; set; }
    public string? Message { get; set; }
}
