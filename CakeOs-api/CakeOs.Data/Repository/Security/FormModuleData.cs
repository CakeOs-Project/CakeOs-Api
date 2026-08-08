using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Formulario-Módulo.
/// Proporciona operaciones CRUD básicas para la gestión de relaciones entre formularios y módulos.
/// </summary>
public class FormModuleData : DataBase<FormModule>, IFormModuleRepository
{
    private readonly ApplicationDbContext _context;

    public FormModuleData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Obtiene todas las relaciones FormModule con sus entidades relacionadas (Form y Module).
    /// </summary>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Colección de FormModule con Form y Module cargados.</returns>
    public override async Task<IEnumerable<FormModule>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<FormModule>()
            .Include(fm => fm.Form)
            .Include(fm => fm.Module)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Obtiene todas las relaciones FormModule activas con sus entidades relacionadas (Form y Module).
    /// </summary>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Colección de FormModule activos con Form y Module cargados.</returns>
    public override async Task<IEnumerable<FormModule>> GetAllActiveAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<FormModule>()
            .Include(fm => fm.Form)
            .Include(fm => fm.Module)
            .Where(fm => fm.IsActive)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
