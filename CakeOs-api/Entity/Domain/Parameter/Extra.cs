
using CakeOs.Entity.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.Domain.Parameter
{
    public class Extra : BaseTenantDomain
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
