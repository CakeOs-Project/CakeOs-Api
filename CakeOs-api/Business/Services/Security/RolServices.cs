using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Rol;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Services.Security
{
    public class RolServices : TenantServicesBase<RolListDto, RolCreateDto, Rol>, IRolServices
    {
        public RolServices(IRolRepository repository, IMapper mapper, ILoggerFactory loggerFactory, ITenantProvider tenantProvider)
            : base(repository, mapper, loggerFactory, tenantProvider)
        {
        }
    }
}
