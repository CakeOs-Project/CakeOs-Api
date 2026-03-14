using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Permiso.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPermissionData : IData<Permission>
{
    /// <summary>
    /// Obtiene todos los permisos del sistema.
    /// </summary>
    /// <returns>Lista de todos los permisos</returns>
    Task<IEnumerable<Permission>> GetAllPermissionsAsync();

    /// <summary>
    /// Obtiene un permiso por su nombre.
    /// </summary>
    /// <param name="permissionName">Nombre del permiso</param>
    /// <returns>Permiso encontrado o null</returns>
    Task<Permission?> GetByNameAsync(string permissionName);

    /// <summary>
    /// Obtiene todos los permisos asociados a un rol.
    /// </summary>
    /// <param name="roleId">Identificador del rol</param>
    /// <returns>Lista de permisos del rol</returns>
    Task<IEnumerable<Permission>> GetByRoleIdAsync(int roleId);
}
