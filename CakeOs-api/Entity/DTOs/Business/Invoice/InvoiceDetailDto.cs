using CakeOs.Entity.Enum.Invoice;
using CakeOS.Entity.DTOs.Business.InvoiceItem;
using CakeOS.Entity.DTOs.Business.Payment;

namespace CakeOS.Entity.DTOs.Business.Invoice
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ClientFullName { get; set; }
        public string ClientTypeDocument { get; set; }
        public string ClientDocument { get; set; }
        public string ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal Total { get; set; }
        public decimal OutstandingBalance { get; set; }
        public string CreatedByFullName { get; set; }
        public List<InvoiceItemDetailDto> Items { get; set; }
        public List<PaymentListDto> Payments { get; set; }
    }
}