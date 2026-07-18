using CakeOs.Business.Base;
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
    }
}
