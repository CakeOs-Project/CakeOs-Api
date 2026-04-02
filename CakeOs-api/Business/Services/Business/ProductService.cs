using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Product;

namespace CakeOs.Business.Services.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con productos.
    /// </summary>
    public class ProductService : BaseService<Product, ProductUpdateDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de productos.
        /// </summary>
        /// <param name="data">Repositorio de datos de productos.</param>
        public ProductService(IData<Product> data) : base(data)
        {
        }

        /// <summary>
        /// Convierte un DTO a una entidad Product.
        /// </summary>
        protected override Product MapToEntity(ProductUpdateDto dto)
        {
            return new Product
            {
                Name = dto.Name ?? string.Empty,
                TypeId = dto.TypeId,
                SizeId = dto.SizeId,
                ShapeId = dto.ShapeId,
                Price = dto.Price,
                Description = dto.Description
            };
        }

        /// <summary>
        /// Actualiza una entidad Product existente con los datos del DTO.
        /// </summary>
        protected override void MapToEntity(ProductUpdateDto dto, Product entity)
        {
            entity.Name = dto.Name ?? entity.Name;
            entity.TypeId = dto.TypeId;
            entity.SizeId = dto.SizeId;
            entity.ShapeId = dto.ShapeId;
            entity.Price = dto.Price;
            entity.Description = dto.Description;
        }

        /// <summary>
        /// Convierte una entidad Product a un DTO.
        /// </summary>
        protected override ProductUpdateDto MapToDto(Product entity)
        {
            return new ProductUpdateDto
            {
                Id = entity.Id,
                Name = entity.Name?.ToString() ?? string.Empty,
                TypeId = entity.TypeId,
                SizeId = entity.SizeId,
                ShapeId = entity.ShapeId,
                Price = entity.Price,
                Description = entity.Description
            };
        }
    }
}
