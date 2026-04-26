using CakeOs.Entity.Enum;

namespace CakeOS.Entity.DTOs.Business.Invoice
{
    public class InvoiceListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal Total { get; set; }
        public decimal OutstandingBalance { get; set; }
    }
}