using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Shape;
using MapsterMapper;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con los parámetros de Forma (Shape).
    /// Implementa los casos de uso para crear, editar, activar/desactivar y listar formas.
    /// 
    /// Casos de Uso:
    /// CU-20: Crear parámetro de forma
    /// CU-21: Editar parámetro de forma
    /// CU-22: Activar/Desactivar parámetro de forma
    /// CU-23: Listar parámetros de forma
    /// </summary>
    public class ShapeService : ServicesBase<ShapeListDTO, ShapeCreateDTO, Shape>, IShapeServices
    {
        private readonly IShapeRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de Forma.
        /// </summary>
        /// <param name="repository">Repositorio de datos para la entidad Shape</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs</param>
        /// <exception cref="ArgumentNullException">Si el repositorio o mapper es nulo</exception>
        public ShapeService(IShapeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
