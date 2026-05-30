using CakeOs.Entity.Domain.Security;
using CakeOS.Entity.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.Domain.Base
{
    public abstract class BaseTenantDomain : BaseDomain
    {
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
    }
}
