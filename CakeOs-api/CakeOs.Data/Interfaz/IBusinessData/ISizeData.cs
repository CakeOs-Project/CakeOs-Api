using CakeOs.Data.Interfaz.IData;

using CakeOS.Entity.Domain.Business;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Tamaño.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface ISizeData : IData<Size>
{
    /// <summary>
    /// CU-23: Obtiene todos los tamaños activos del sistema.
    /// </summary>
    /// <returns>Lista de tamaños activos</returns>
    Task<IEnumerable<Size>> GetActiveSizesAsync();

    
}
