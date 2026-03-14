using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Business;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Forma.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IShapeData : IData<Shape>
{
    /// <summary>
    /// CU-23: Obtiene todas las formas activas del sistema.
    /// </summary>
    /// <returns>Lista de formas activas</returns>
    Task<IEnumerable<Shape>> GetActiveShapesAsync();

    
}
