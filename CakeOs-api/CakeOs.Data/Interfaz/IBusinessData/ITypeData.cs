using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Parameter;
using TypeCake = CakeOs.Entity.Domain.Parameter.Type;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Tipo.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface ITypeData : IData<TypeCake>
{
    /// <summary>
    /// CU-23: Obtiene todos los tipos activos del sistema.
    /// </summary>
    /// <returns>Lista de tipos activos</returns>
    Task<IEnumerable<TypeCake>> GetActiveTypesAsync();

  
}
