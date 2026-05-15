using CakeOs.Entity.Enum.Payment;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOS.Entity.Domain.Business
{
    public class Payment : BaseDomain
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }

        ///
        /// Relaciones
        ///
        public Invoice? Invoice { get; set; }
        public User? User { get; set; }
    }
}