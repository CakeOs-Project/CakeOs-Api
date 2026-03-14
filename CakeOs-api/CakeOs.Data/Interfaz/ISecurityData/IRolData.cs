using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Rol.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IRolData : IData<Rol>
{
    /// <summary>
    /// Obtiene un rol por su nombre.
    /// </summary>
    /// <param name="rolName">Nombre del rol</param>
    /// <returns>Rol encontrado o null</returns>
    Task<Rol?> GetByNameAsync(string rolName);

    /// <summary>
    /// CU-07: Obtiene un rol con todos sus permisos asignados.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <returns>Rol con sus permisos</returns>
    Task<Rol?> GetWithPermissionsAsync(int rolId);
}
