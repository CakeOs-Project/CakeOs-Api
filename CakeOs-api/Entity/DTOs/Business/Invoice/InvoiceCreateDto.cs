namespace CakeOS.Entity.DTOs.Business.Invoice
{
    public class InvoiceCreateDto
    {
        public int ClientId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? Observations { get; set; }
        public decimal? InitialPayment { get; set; }
        public string? PaymentMethod { get; set; }
        public List<InvoiceItemCreateDto> Items { get; set; } = new List<InvoiceItemCreateDto>();
    }
}