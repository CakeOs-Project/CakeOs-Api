using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Type;
using CakeOs.Business.Interfaces.Parameter;
using MapsterMapper;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con tipos.
    /// </summary>
    public class TypeService : ServicesBase<TypeListDto, TypeCreateDto, Types>, ITypeServices
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de tipos.
        /// </summary>
        /// <param name="data">Repositorio de datos de tipos.</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs.</param>
        public TypeService(IData<Types> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
