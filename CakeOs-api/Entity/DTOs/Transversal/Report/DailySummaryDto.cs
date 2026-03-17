using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Transversal.Report
{
    public class DailySummaryDto
    {
        public DateTime Date { get; set; }
        public int TotalInvoices { get; set; }
        public int InvoicesPending { get; set; }
        public int InvoicesReady { get; set; }
        public int InvoicesPaid { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalCollected { get; set; }
        public decimal TotalOutstanding { get; set; }
    }
}
