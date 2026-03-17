namespace CakeOS.Entity.DTOs.Business.Payment
{
    public class PaymentCreateDto
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentType { get; set; }
    }
}