using CakeOs.Data.Base;
using CakeOs.Entity.Domain.Base;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Base
{
    public class TenantServicesBase<TDtoList, TDtoCreate, TEntity>
        : ServicesBase<TDtoList, TDtoCreate, TEntity>
        where TDtoList : class
        where TDtoCreate : class
        where TEntity : BaseTenantDomain
    {
        protected readonly ITenantProvider _tenantProvider;

        public TenantServicesBase(IData<TEntity> repository, IMapper mapper, ILoggerFactory loggerFactory, ITenantProvider tenantProvider)
            : base(repository, mapper, loggerFactory)
        {
            _tenantProvider = tenantProvider;
        }

        public override async Task<TDtoList> CreateAsync(TDtoCreate dto)
        {
            try
            {
                if (dto is null) throw new ArgumentNullException(nameof(dto), "El DTO no puede ser nulo.");
                if (_tenantProvider.TenantId is null)
                    throw new InvalidOperationException("No se pudo determinar el TenantId para la operación.");

                var candidate = _mapper.Map<TEntity>(dto);
                candidate.TenantId = _tenantProvider.TenantId.Value;

                var entity = await _repository.AddAsync(candidate);
                await _repository.SaveChangesAsync();

                var createdEntity = await _repository.GetByIdAsync(entity.Id);
                return _mapper.Map<TDtoList>(createdEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear {Entity} para tenant {TenantId}", typeof(TEntity).Name, _tenantProvider.TenantId);
                throw new("Error al crear el registro.", ex);
            }
        }
    }
}
