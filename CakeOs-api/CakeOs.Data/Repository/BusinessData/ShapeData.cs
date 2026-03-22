using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;
using CakeOS.Entity.Domain.Business;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Forma.
/// Proporciona operaciones CRUD básicas para la gestión de formas de productos.
/// </summary>
public class ShapeData : Data<Shape>, IShapeData
{
    private readonly ApplicationDbContext _context;

    public ShapeData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// CU-23: Obtiene todas las formas activas del sistema.
    /// </summary>
    /// <returns>Lista de formas activas</returns>
    public async Task<IEnumerable<Shape>> GetActiveShapesAsync()
    {
        return await _context.Set<Shape>()
            .Where(s => s.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }
}
