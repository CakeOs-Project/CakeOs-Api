using CakeOs.Entity.Domain.Base;
using CakeOs.Entity.Domain.Business;
using CakeOS.Entity.Domain.Base;

namespace CakeOs.Entity.Domain.Parameter
{
    public class Shape : BaseTenantDomain
    {
        public string Name { get; set; } = string.Empty;

        ///
        /// Relaciones
        ///
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}