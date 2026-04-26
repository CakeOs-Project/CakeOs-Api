using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Shape;
using CakeOs.Business.Interfaces.Parameter;
using MapsterMapper;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con formas.
    /// </summary>
    public class ShapeService : ServicesBase<ShapeListDTO, ShapeCreateDTO, Shape>, IShapeServices
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de formas.
        /// </summary>
        /// <param name="data">Repositorio de datos de formas.</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs.</param>
        public ShapeService(IData<Shape> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
