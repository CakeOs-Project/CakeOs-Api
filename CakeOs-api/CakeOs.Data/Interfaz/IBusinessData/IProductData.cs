using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Business;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Producto.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IProductData : IData<Product>
{
    

    /// <summary>
    /// Busca productos por nombre.
    /// </summary>
    /// <param name="name">Nombre del producto a buscar</param>
    /// <returns>Lista de productos que coinciden</returns>
    Task<IEnumerable<Product>> SearchByNameAsync(string name);

 
}