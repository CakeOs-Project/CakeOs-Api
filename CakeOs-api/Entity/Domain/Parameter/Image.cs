using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Entity.Domain.Parameter
{
    public class Image : BaseDomain
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }

        /// 
        /// Relaciones
        /// 
        public ICollection<InvoiceItem?> InvoiceItems { get; set; } = new List<InvoiceItem?>();

    }
}
