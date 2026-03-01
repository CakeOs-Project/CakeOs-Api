namespace CakeOS.Entity.DTOs.BusinessDtos.PagoDtos;

public class PagoCreateDTO
{
    public int InvoiceId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PaymentType { get; set; } = string.Empty;
}
