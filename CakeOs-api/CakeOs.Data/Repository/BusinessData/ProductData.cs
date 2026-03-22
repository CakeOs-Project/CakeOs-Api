using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Business;

using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Producto.
/// Proporciona operaciones CRUD y métodos específicos de búsqueda.
/// </summary>
public class ProductData : Data<Product>, IProductData
{
    private readonly ApplicationDbContext _context;

    public ProductData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Busca productos por nombre que coincidan con el término de búsqueda.
    /// </summary>
    /// <param name="name">Nombre del producto a buscar</param>
    /// <returns>Lista de productos que coinciden con el nombre</returns>
    public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        // Convertir a List primero para ejecutar en memoria
        var products = await _context.Set<Product>()
            .ToListAsync();

        if (string.IsNullOrEmpty(name))
            return products;

        return products
            .Where(p => p.Name?.ToString()?.Contains(name, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();
    }
}
