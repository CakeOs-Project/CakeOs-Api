using CakeOs.Entity.Enum.Payment;

namespace CakeOS.Entity.DTOs.Business.Payment
{
    public class PaymentListDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public string RegisteredByFullName { get; set; }
    }
}