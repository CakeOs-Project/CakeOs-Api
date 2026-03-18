using CakeOS.Entity.DTOs.Business.InvoiceItem;

namespace CakeOs.Entity.DTOs.Transversal.Notification
{
    public class NotificationDto
    {
        public string ToEmail { get; set; }
        public string ClientFullName { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Total { get; set; }
        public decimal OutstandingBalance { get; set; }
        public List<InvoiceItemDetailDto> Items { get; set; }
    }
}