using CakeOs.Entity.Enum.Invoice;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOS.Entity.Domain.Business
{
    public class Invoice : BaseDomain
    {
        public string Code { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public decimal OutstandingBalance { get; set; }
        public InvoiceStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryDate { get; set; }

        ///
        /// Relaciones
        ///
        public Client Client { get; set; }
        public User? User { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}