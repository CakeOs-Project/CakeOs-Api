using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOS.Utilities.Provider
{
    public interface ITenantProvider
    {
        int? TenantId { get; }
    }
}
