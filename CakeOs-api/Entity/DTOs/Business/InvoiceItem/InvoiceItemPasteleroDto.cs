using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Business.InvoiceItem
{
    public class InvoiceItemPasteleroDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public bool HasFilling { get; set; }
        public string? FilledName { get; set; }
        public bool HasDecoration { get; set; }
        public string? DecorationImageUrl { get; set; }
        public string? DecorationDescription { get; set; }
        public bool HasMessage { get; set; }
        public string? Message { get; set; }
    }
}
