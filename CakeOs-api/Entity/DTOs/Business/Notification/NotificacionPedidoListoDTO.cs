namespace CakeOS.Entity.DTOs.BusinessDtos.NotificacionesDtos;

public class NotificacionPedidoListoDTO
{
    public int InvoiceId { get; set; }
    public string ClienteEmail { get; set; } = string.Empty;
    public string ClienteNombre { get; set; } = string.Empty;
    public string CodigoFactura { get; set; } = string.Empty;
    public DateTime FechaEntrega { get; set; }
}
