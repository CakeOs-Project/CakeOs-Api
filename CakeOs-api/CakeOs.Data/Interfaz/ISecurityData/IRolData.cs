using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Rol.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IRolData : IData<Rol>
{
    // Aquí se pueden agregar métodos específicos para Rol si es necesario
    // Por ejemplo: Task<Rol?> GetByNameAsync(string rolName);
}
