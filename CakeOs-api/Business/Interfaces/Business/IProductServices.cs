using CakeOs.Business.Base;
using CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;
using CakeOs.Entity.Domain.Business;

namespace CakeOs.Business.Interfaces.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con productos.
    /// CU-16: Crear producto
    /// CU-17: Editar producto
    /// CU-18: Activar/Desactivar producto
    /// CU-19: Listar productos
    /// </summary>
    public interface IProductServices : IServices<ProductListDto, ProductCreateDto, Product>
    {
        /// <summary>
        /// Busca productos por nombre.
        /// </summary>
        /// <param name="name">Nombre del producto a buscar</param>
        /// <returns>Lista de productos que coinciden</returns>
        Task<IEnumerable<ProductListDto>> SearchByNameAsync(string name);
    }
}
