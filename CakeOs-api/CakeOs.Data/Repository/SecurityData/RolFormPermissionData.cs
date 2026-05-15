using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Rol-Formulario-Permiso.
/// Proporciona operaciones CRUD y métodos específicos para gestión de permisos por rol.
/// </summary>
public class RolFormPermissionData : DataBase<RolFormPermission>, IRolFormPermissionRepository
{
    private readonly ApplicationDbContext _context;

    public RolFormPermissionData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// CU-07: Obtiene todos los permisos asignados a un rol.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <returns>Lista de permisos del rol</returns>
    public async Task<IEnumerable<RolFormPermission>> GetByRolIdAsync(int rolId)
    {
        return await _context.Set<RolFormPermission>()
            .Where(rfp => rfp.RolId == rolId)
            .Include(rfp => rfp.Form)
            .Include(rfp => rfp.Permission)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene permisos específicos de un rol para un formulario.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <param name="formId">Identificador del formulario</param>
    /// <returns>Lista de permisos del rol en ese formulario</returns>
    public async Task<IEnumerable<RolFormPermission>> GetPermissionsByRolAndFormAsync(int rolId, int formId)
    {
        return await _context.Set<RolFormPermission>()
            .Where(rfp => rfp.RolId == rolId && rfp.FormId == formId)
            .Include(rfp => rfp.Permission)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// CU-07: Asigna múltiples permisos a un rol para un formulario.
    /// </summary>
    /// <param name="permissions">Lista de permisos a asignar</param>
    /// <returns>True si se asignaron correctamente</returns>
    public async Task<bool> AssignPermissionsAsync(IEnumerable<RolFormPermission> permissions)
    {
        var permissionsList = permissions.ToList();
        await _context.Set<RolFormPermission>().AddRangeAsync(permissionsList);
        return true;
    }

    /// <summary>
    /// Elimina todos los permisos de un rol para un formulario específico.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <param name="formId">Identificador del formulario</param>
    /// <returns>True si se eliminaron correctamente</returns>
    public async Task<bool> RemovePermissionsByRolAndFormAsync(int rolId, int formId)
    {
        var permissions = await _context.Set<RolFormPermission>()
            .Where(rfp => rfp.RolId == rolId && rfp.FormId == formId)
            .ToListAsync();

        if (permissions.Count == 0) return false;

        _context.Set<RolFormPermission>().RemoveRange(permissions);
        return true;
    }
}
