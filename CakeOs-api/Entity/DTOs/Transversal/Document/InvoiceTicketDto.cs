using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Transversal.Document
{
    public class InvoiceTicketDto
    {
        public string Code { get; set; }
        public string ClientFullName { get; set; }
        public string ClientPhone { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal OutstandingBalance { get; set; }
        public List<string> ItemsSummary { get; set; }
    }
}
