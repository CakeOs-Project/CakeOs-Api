using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Rol.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IRoleData : IData<Rol>
{
    /// <summary>
    /// CU-08: Obtiene todos los roles del sistema.
    /// </summary>
    /// <returns>Lista de todos los roles</returns>
    Task<IEnumerable<Rol>> GetAllRolesAsync();

    /// <summary>
    /// Obtiene un rol por su nombre.
    /// </summary>
    /// <param name="roleName">Nombre del rol</param>
    /// <returns>Rol encontrado o null</returns>
    Task<Rol?> GetByNameAsync(string roleName);

    /// <summary>
    /// Obtiene un rol con todos sus detalles (incluyendo permisos).
    /// </summary>
    /// <param name="roleId">Identificador del rol</param>
    /// <returns>Rol con sus detalles</returns>
    Task<Rol?> GetWithPermissionsAsync(int roleId);

    /// <summary>
    /// CU-07: Asigna o actualiza los permisos asociados a un rol.
    /// </summary>
    /// <param name="roleId">Identificador del rol</param>
    /// <param name="permissionIds">Lista de identificadores de permisos</param>
    /// <returns>True si se asignaron correctamente</returns>
    Task<bool> AssignPermissionsAsync(int roleId, IEnumerable<int> permissionIds);

    /// <summary>
    /// Obtiene los permisos de un rol específico.
    /// </summary>
    /// <param name="roleId">Identificador del rol</param>
    /// <returns>Lista de permisos del rol</returns>
    Task<IEnumerable<Permission>> GetPermissionsByRoleAsync(int roleId);
}
