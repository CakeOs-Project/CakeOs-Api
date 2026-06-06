using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Entity.Domain.Parameter
{
    public class Filled : BaseTenantDomain
    {
        public string Name { get; set; } = string.Empty;
        public Boolean DefaultFilled { get; set; }

        ///
        /// Relaciones
        ///
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}