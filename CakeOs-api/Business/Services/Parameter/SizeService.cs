using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Size;
using CakeOs.Business.Interfaces.Parameter;
using MapsterMapper;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con tamaños.
    /// </summary>
    public class SizeService : ServicesBase<SizeListDTO, SizeCreateDTO, Size>, ISizeServices
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de tamaños.
        /// </summary>
        /// <param name="data">Repositorio de datos de tamaños.</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs.</param>
        public SizeService(IData<Size> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
