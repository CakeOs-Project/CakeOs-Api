using CakeOs.Entity.Domain.Parameter;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.Domain.Business
{
    public class InvoiceItemExtra : BaseDomain
    {
        public int InvoiceItemId { get; set; }
        public int ExtraId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        // Relaciones
        public InvoiceItem InvoiceItem { get; set; }
        public Extra Extra { get; set; }
    }
}
