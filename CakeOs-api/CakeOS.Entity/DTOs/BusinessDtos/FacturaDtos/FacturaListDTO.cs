namespace CakeOS.Entity.DTOs.BusinessDtos.FacturaDtos;

public class FacturaListDTO
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string ClienteNombre { get; set; } = string.Empty;
    public string UsuarioEmail { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public decimal OutstandingBalance { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime DeliveryDate { get; set; }
    public bool IsActive { get; set; }
}
