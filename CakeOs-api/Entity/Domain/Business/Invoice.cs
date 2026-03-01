using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Invoice : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public decimal Total { get; set; }
    public decimal OutstandingBalance { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime DeliveryDate { get; set; }

    public Client? Client { get; set; }
    public User? User { get; set; }
    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
