using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Transversal.Report
{
    public class PaymentMethodSummaryDto
    {
        public string PaymentMethod { get; set; }
        public int TotalTransactions { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Percentage { get; set; }
    }
}
