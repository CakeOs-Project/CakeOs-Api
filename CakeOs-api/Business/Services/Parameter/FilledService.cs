using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Filled;
using MapsterMapper;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con los parámetros de Relleno (Filled).
    /// Implementa los casos de uso para crear, editar, activar/desactivar y listar rellenos.
    /// 
    /// Casos de Uso:
    /// CU-20: Crear parámetro de relleno
    /// CU-21: Editar parámetro de relleno
    /// CU-22: Activar/Desactivar parámetro de relleno
    /// CU-23: Listar parámetros de relleno
    /// </summary>
    public class FilledService : ServicesBase<FilledListDto, FilledCreateDto, Filled>, IFilledServices
    {
        private readonly IFilledRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de Relleno.
        /// </summary>
        /// <param name="repository">Repositorio de datos para la entidad Filled</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs</param>
        /// <exception cref="ArgumentNullException">Si el repositorio o mapper es nulo</exception>
        public FilledService(IFilledRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
