using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Size;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con los parámetros de Tamaño (Size).
    /// Implementa los casos de uso para crear, editar, activar/desactivar y listar tamaños.
    /// 
    /// Casos de Uso:
    /// CU-20: Crear parámetro de tamaño
    /// CU-21: Editar parámetro de tamaño
    /// CU-22: Activar/Desactivar parámetro de tamaño
    /// CU-23: Listar parámetros de tamaño
    /// </summary>
    public class SizeService : TenantServicesBase<SizeListDTO, SizeCreateDTO, Size>, ISizeServices
    {
        private readonly ISizeRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de Tamaño.
        /// </summary>
        /// <param name="repository">Repositorio de datos para la entidad Size</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs</param>
        /// <param name="tenantProvider">Proveedor del TenantId activo</param>
        /// <exception cref="ArgumentNullException">Si el repositorio o mapper es nulo</exception>
        public SizeService(ISizeRepository repository, IMapper mapper, ILoggerFactory loggerFactory, ITenantProvider tenantProvider)
            : base(repository, mapper, loggerFactory, tenantProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
