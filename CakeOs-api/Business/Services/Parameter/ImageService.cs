using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Image;
using CakeOs.Business.Interfaces.Parameter;
using MapsterMapper;

namespace CakeOs.Business.Services.Parameter
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con imágenes.
    /// </summary>
    public class ImageService : ServicesBase<ImageListDto, ImageUpdateDto, Image>, IImageServices
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de imágenes.
        /// </summary>
        /// <param name="data">Repositorio de datos de imágenes.</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs.</param>
        public ImageService(IData<Image> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
