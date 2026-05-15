using CakeOs.Entity.Enum.Payment;

namespace CakeOS.Entity.DTOs.Business.Payment
{
    public class PaymentCreateDto
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}