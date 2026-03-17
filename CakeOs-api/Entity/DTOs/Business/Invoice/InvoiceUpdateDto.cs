namespace CakeOS.Entity.DTOs.Business.Invoice
{
    public class InvoiceUpdateDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? Observations { get; set; }
        public List<InvoiceItemCreateDto> Items { get; set; } = new List<InvoiceItemCreateDto>();
    }
}