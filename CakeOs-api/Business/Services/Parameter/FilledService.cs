using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Filled;
using CakeOs.Business.Interfaces.Parameter;
using MapsterMapper;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con rellenos.
    /// </summary>
    public class FilledService : ServicesBase<FilledListDto, FilledCreateDto, Filled>, IFilledServices
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de rellenos.
        /// </summary>
        /// <param name="data">Repositorio de datos de rellenos.</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs.</param>
        public FilledService(IData<Filled> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
