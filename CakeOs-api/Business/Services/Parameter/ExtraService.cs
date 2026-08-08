using CakeOs.Business.Base;
using CakeOs.Business.Exceptions;
using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Extras;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Services.Parameter
{
    public class ExtraService : TenantServicesBase<ExtraListDto, ExtraCreateDto, Extra>, IExtraServices
    {
        private readonly IExtraRepository _repository;
        private readonly IMapper _mapper;

        public ExtraService(IExtraRepository repository, IMapper mapper, ILoggerFactory loggerFactory, ITenantProvider tenantProvider)
            : base(repository, mapper, loggerFactory, tenantProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<ExtraListDto> CreateAsync(ExtraCreateDto dto) 
        {
            try
            {
                if (dto is null) throw new ArgumentNullException(nameof(dto), "El DTO no puede ser nulo.");
                
                if (dto.Price <= 0) throw new ArgumentNullException(nameof(dto), "El Pricio no puede ser 0 o menos a cero.");

                if (_tenantProvider.TenantId is null)
                    throw new InvalidOperationException("No se pudo determinar el TenantId para la operación.");

                var extraExist = await _repository.GetByName(dto.Name);
                
                if (extraExist is not null)
                {
                    throw new InvalidOperationException($"Ya existe un extra con el nombre '{dto.Name}'.");
                }

                var candidate = _mapper.Map<Extra>(dto);
                candidate.TenantId = _tenantProvider.TenantId.Value;
                var entity = await _repository.AddAsync(candidate);
                await _repository.SaveChangesAsync();

                var createdEntity = await _repository.GetByIdAsync(entity.Id);
                return _mapper.Map<ExtraListDto>(createdEntity);
            }
            catch (Exception ex) when (ex is not ArgumentException and not ServiceException)
            {
                _logger.LogError(ex, "Error al crear {Extra}", typeof(Extra).Name);
                throw new("Error al crear el registro.", ex);
            }
        }
    }
}
