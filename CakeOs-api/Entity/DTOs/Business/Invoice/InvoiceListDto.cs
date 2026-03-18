namespace CakeOS.Entity.DTOs.Business.Invoice
{
    public class InvoiceListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ClientFullName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public decimal OutstandingBalance { get; set; }
    }
}