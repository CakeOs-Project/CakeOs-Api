using CakeOs.Data.Interfaz.ISecurityData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Rol.
/// Proporciona operaciones CRUD y métodos específicos para gestión de roles.
/// </summary>
public class RolData : Data<Rol>, IRolData
{
    private readonly ApplicationDbContext _context;

    public RolData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Obtiene un rol por su nombre.
    /// </summary>
    /// <param name="rolName">Nombre del rol</param>
    /// <returns>Rol encontrado o null</returns>
    public async Task<Rol?> GetByNameAsync(string rolName)
    {
        return await _context.Set<Rol>()
            .FirstOrDefaultAsync(r => r.Name == rolName);
    }

    /// <summary>
    /// CU-07: Obtiene un rol con todos sus permisos asignados.
    /// </summary>
    /// <param name="rolId">Identificador del rol</param>
    /// <returns>Rol con sus permisos</returns>
    public async Task<Rol?> GetWithPermissionsAsync(int rolId)
    {
        return await _context.Set<Rol>()
            .Include(r => r.RolFormPermissions)
                .ThenInclude(rfp => rfp.Form)
            .Include(r => r.RolFormPermissions)
                .ThenInclude(rfp => rfp.Permission)
            .FirstOrDefaultAsync(r => r.Id == rolId);
    }
}
