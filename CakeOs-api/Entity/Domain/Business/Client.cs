using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOS.Entity.Domain.Business
{
    public class Client : BaseTenantDomain
    {
        public int PersonId { get; set; }
        public string Email { get; set; }

        /// 
        /// Relaciones
        /// 
        public Person Person { get; set; }
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}


