using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Producto.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IProductData : IData<Product>
{
    // Aquí se pueden agregar métodos específicos para Producto si es necesario
    // Por ejemplo: Task<IEnumerable<Product>> GetActiveProductsAsync();
}
