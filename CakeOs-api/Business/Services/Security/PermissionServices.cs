using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PermisoDtos;
using MapsterMapper;

namespace CakeOs.Business.Services.Security
{
    public class PermissionServices : ServicesBase<PermissionListDTO, PermissionCreateDTO, Permission>, IPermissionServices
    {
        public PermissionServices(IPermissionRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
