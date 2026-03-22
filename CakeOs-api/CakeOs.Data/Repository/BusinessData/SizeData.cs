using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Tamaño.
/// Proporciona operaciones CRUD básicas para la gestión de tamaños de productos.
/// </summary>
public class SizeData : Data<Size>, ISizeData
{
    private readonly ApplicationDbContext _context;

    public SizeData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// CU-23: Obtiene todos los tamaños activos del sistema.
    /// </summary>
    /// <returns>Lista de tamaños activos</returns>
    public async Task<IEnumerable<Size>> GetActiveSizesAsync()
    {
        return await _context.Set<Size>()
            .Where(s => s.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }
}
