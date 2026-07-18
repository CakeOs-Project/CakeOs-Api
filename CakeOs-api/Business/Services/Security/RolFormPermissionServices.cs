using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Services.Security
{
    public class RolFormPermissionServices
        : TenantServicesBase<RolFormPermissionListDTO, RolFormPermissionCreateDTO, RolFormPermission>,
            IRolFormPermissionServices
    {
        private readonly IRolFormPermissionRepository _repository;
        private readonly IMapper _mapper;

        public RolFormPermissionServices(
            IRolFormPermissionRepository repository,
            IMapper mapper,
            ILoggerFactory loggerFactory,
            ITenantProvider tenantProvider)
            : base(repository, mapper, loggerFactory, tenantProvider)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolFormPermissionListDTO>> GetByRolIdAsync(int rolId)
        {
            if (rolId <= 0)
                throw new ArgumentOutOfRangeException(nameof(rolId), "El rolId debe ser mayor que cero.");

            var entities = await _repository.GetByRolIdAsync(rolId);
            return _mapper.Map<IEnumerable<RolFormPermissionListDTO>>(entities);
        }
    }
}
