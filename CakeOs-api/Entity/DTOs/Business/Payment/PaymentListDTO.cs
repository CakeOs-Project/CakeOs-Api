namespace CakeOS.Entity.DTOs.Business.Payment
{
    public class PaymentListDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public string RegisteredByFullName { get; set; }
    }
}