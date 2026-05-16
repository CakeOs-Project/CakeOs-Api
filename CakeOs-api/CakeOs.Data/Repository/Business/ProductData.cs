using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Business;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Producto.
/// Proporciona operaciones CRUD y métodos específicos de búsqueda.
/// </summary>
public class ProductData : DataBase<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Obtiene un producto específico por su ID con sus relaciones cargadas.
    /// </summary>
    /// <param name="id">ID del producto</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>El producto encontrado o null si no existe.</returns>
    public override async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>()
            .Include(p => p.Type)
            .Include(p => p.Size)
            .Include(p => p.Shape)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    /// <summary>
    /// Obtiene todos los productos con sus relaciones cargadas.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Una colección de todos los productos.</returns>
    public override async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>()
            .Include(p => p.Type)
            .Include(p => p.Size)
            .Include(p => p.Shape)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Obtiene todos los productos activos con sus relaciones cargadas.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Una colección de todos los productos activos.</returns>
    public override async Task<IEnumerable<Product>> GetAllActiveAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>()
            .Include(p => p.Type)
            .Include(p => p.Size)
            .Include(p => p.Shape)
            .Where(p => p.IsActive)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Busca productos por nombre que coincidan con el término de búsqueda.
    /// </summary>
    /// <param name="name">Nombre del producto a buscar</param>
    /// <returns>Lista de productos que coinciden con el nombre</returns>
    public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        var query = _context.Set<Product>()
            .Include(p => p.Type)
            .Include(p => p.Size)
            .Include(p => p.Shape)
            .AsNoTracking();

        if (string.IsNullOrEmpty(name))
            return await query.ToListAsync();

        return await query
            .Where(p => p.Name != null && EF.Functions.Like(p.Name, $"%{name}%"))
            .ToListAsync();
    }
}
