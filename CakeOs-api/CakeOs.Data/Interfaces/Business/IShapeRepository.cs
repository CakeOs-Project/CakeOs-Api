using CakeOs.Data.Base;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Interfaces.Business;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Forma.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IShapeRepository : IData<Shape>
{
    /// <summary>
    /// CU-23: Obtiene todas las formas activas del sistema.
    /// </summary>
    /// <returns>Lista de formas activas</returns>
    Task<IEnumerable<Shape>> GetActiveShapesAsync();

    
}
