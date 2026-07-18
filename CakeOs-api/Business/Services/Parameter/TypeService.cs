using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Type;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con los parámetros de Tipo (Type).
    /// Implementa los casos de uso para crear, editar, activar/desactivar y listar tipos.
    /// 
    /// Casos de Uso:
    /// CU-20: Crear parámetro de tipo
    /// CU-21: Editar parámetro de tipo
    /// CU-22: Activar/Desactivar parámetro de tipo
    /// CU-23: Listar parámetros de tipo
    /// </summary>
    public class TypeService : TenantServicesBase<TypeListDto, TypeCreateDto, Types>, ITypeServices
    {
        private readonly ITypeRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de Tipo.
        /// </summary>
        /// <param name="repository">Repositorio de datos para la entidad Types</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs</param>
        /// <param name="tenantProvider">Proveedor del TenantId activo</param>
        /// <exception cref="ArgumentNullException">Si el repositorio o mapper es nulo</exception>
        public TypeService(ITypeRepository repository, IMapper mapper, ILoggerFactory loggerFactory, ITenantProvider tenantProvider)
            : base(repository, mapper, loggerFactory, tenantProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
