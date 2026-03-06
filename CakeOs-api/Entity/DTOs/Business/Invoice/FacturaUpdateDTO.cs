namespace CakeOS.Entity.DTOs.BusinessDtos.FacturaDtos;

public class FacturaUpdateDTO
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime DeliveryDate { get; set; }
    public bool IsActive { get; set; }
}
