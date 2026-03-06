namespace CakeOS.Entity.DTOs.BusinessDtos.PagoDtos;

public class PaymentHistoryDTO
{
    public int InvoiceId { get; set; }
    public string CodigoFactura { get; set; } = string.Empty;
    public decimal TotalFactura { get; set; }
    public decimal SaldoPendiente { get; set; }
    public List<PagoDetalleDTO> Pagos { get; set; } = new List<PagoDetalleDTO>();
}

public class PagoDetalleDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PaymentType { get; set; } = string.Empty; // "Anticipo", "Final", "Total"
    public DateTime PaymentDate { get; set; }
    public string UsuarioNombre { get; set; } = string.Empty;
}
