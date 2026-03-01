using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Payment : BaseEntity
{
    public int InvoiceId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PaymentType { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }

    public Invoice? Invoice { get; set; }
    public User? User { get; set; }
}
