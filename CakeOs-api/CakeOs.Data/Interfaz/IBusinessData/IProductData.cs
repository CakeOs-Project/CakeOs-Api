using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Producto.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IProductData : IData<Product>
{
    /// <summary>
    /// CU-19: Obtiene todos los productos activos del sistema.
    /// </summary>
    /// <returns>Lista de productos activos</returns>
    Task<IEnumerable<Product>> GetActiveProductsAsync();

    /// <summary>
    /// Busca productos por nombre.
    /// </summary>
    /// <param name="name">Nombre del producto a buscar</param>
    /// <returns>Lista de productos que coinciden</returns>
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
}

    
