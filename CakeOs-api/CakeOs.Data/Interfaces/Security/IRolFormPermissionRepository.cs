using CakeOs.Data.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaces.Security;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Rol-Formulario-Permiso.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IRolFormPermissionRepository : IData<RolFormPermission>
{
    /// <summary>
    /// CU-07: Obtiene todos los permisos asignados a un rol.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <returns>Lista de permisos del rol</returns>
    Task<IEnumerable<RolFormPermission>> GetByRolIdAsync(int rolId);

    /// <summary>
    /// Obtiene permisos específicos de un rol para un formulario.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <param name="formId">Identificador del formulario</param>
    /// <returns>Lista de permisos del rol en ese formulario</returns>
    Task<IEnumerable<RolFormPermission>> GetPermissionsByRolAndFormAsync(int rolId, int formId);

    /// <summary>
    /// CU-07: Asigna múltiples permisos a un rol para un formulario.
    /// </summary>
    /// <param name="permissions">Lista de permisos a asignar</param>
    /// <returns>True si se asignaron correctamente</returns>
    Task<bool> AssignPermissionsAsync(IEnumerable<RolFormPermission> permissions);

    /// <summary>
    /// Elimina todos los permisos de un rol para un formulario específico.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <param name="formId">Identificador del formulario</param>
    /// <returns>True si se eliminaron correctamente</returns>
    Task<bool> RemovePermissionsByRolAndFormAsync(int rolId, int formId);
}
