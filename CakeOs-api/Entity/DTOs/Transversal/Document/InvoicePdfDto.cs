using CakeOS.Entity.DTOs.Business.InvoiceItem;
using CakeOS.Entity.DTOs.Business.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Transversal.Document
{
    public class InvoicePdfDto
    {
        public string Code { get; set; }
        public string ClientFullName { get; set; }
        public string ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public string CreatedByFullName { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal OutstandingBalance { get; set; }
        public List<InvoiceItemDetailDto> Items { get; set; }
        public List<PaymentListDto> Payments { get; set; }
    }
}
