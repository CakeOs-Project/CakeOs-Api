using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Rol;
using CakeOS.Utilities.Provider;
using MapsterMapper;

namespace CakeOs.Business.Services.Security
{
    public class RolServices : TenantServicesBase<RolListDto, RolCreateDto, Rol>, IRolServices
    {
        public RolServices(IRolRepository repository, IMapper mapper, ITenantProvider tenantProvider)
            : base(repository, mapper, tenantProvider)
        {
        }
    }
}
