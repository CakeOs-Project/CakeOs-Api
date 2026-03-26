using CakeOs.Data.Interfaz.ISecurityData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Formulario.
/// Proporciona operaciones CRUD y métodos específicos para gestión de formularios.
/// </summary>
public class FormData : Data<Form>, IFormData
{
    private readonly ApplicationDbContext _context;

    public FormData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Obtiene todos los formularios de un módulo específico.
    /// </summary>
    /// <param name="moduleId">Identificador del módulo</param>
    /// <returns>Lista de formularios del módulo</returns>
    public async Task<IEnumerable<Form>> GetByModuleIdAsync(int moduleId)
    {
        return await _context.Set<Form>()
            .Where(f => f.FormModules.Any(fm => fm.ModuleId == moduleId))
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene formularios activos para mostrar en el menú.
    /// </summary>
    /// <returns>Lista de formularios activos</returns>
    public async Task<IEnumerable<Form>> GetActiveFormsAsync()
    {
        return await _context.Set<Form>()
            .Where(f => f.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }
}
