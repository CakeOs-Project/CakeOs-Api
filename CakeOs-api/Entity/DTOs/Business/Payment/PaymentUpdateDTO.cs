namespace CakeOS.Entity.DTOs.BusinessDtos.PagoDtos;

public class PaymentUpdateDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PaymentType { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
