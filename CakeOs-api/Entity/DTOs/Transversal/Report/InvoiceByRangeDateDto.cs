using CakeOS.Entity.DTOs.Business.Invoice;

namespace CakeOs.Entity.DTOs.Transversal.Report
{
    public class InvoiceByRangeDateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalInvoices { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalCollected { get; set; }
        public decimal TotalOutstanding { get; set; }
        public List<InvoiceListDto> Invoices { get; set; }
    }
}
