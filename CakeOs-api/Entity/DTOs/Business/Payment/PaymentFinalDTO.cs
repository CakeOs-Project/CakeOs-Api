namespace CakeOS.Entity.DTOs.BusinessDtos.PagoDtos;

public class PaymentFinalDTO
{
    public int InvoiceId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // "Efectivo", "Tarjeta", "Transferencia"
}
