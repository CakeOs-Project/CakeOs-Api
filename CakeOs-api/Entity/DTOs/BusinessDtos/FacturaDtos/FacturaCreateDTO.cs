namespace CakeOS.Entity.DTOs.BusinessDtos.FacturaDtos;

public class FacturaCreateDTO
{
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public DateTime DeliveryDate { get; set; }
}
