using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Client;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Cliente.
/// Proporciona operaciones CRUD y métodos de búsqueda específicos.
/// </summary>
public class ClientData : DataBase<Client>, IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public override async Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Client>()
            .Where(c => c.IsActive)
            .Include(c => c.Person)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// CU-13: Busca clientes por nombre o número de teléfono.
    /// </summary>
    /// <param name="searchTerm">Término de búsqueda (nombre o teléfono)</param>
    /// <returns>Lista de clientes que coinciden con la búsqueda</returns>
    public async Task<IEnumerable<Client>> SearchByNameOrPhoneAsync(string searchTerm)
    {
        return await _context.Set<Client>()
            .Include(c => c.Person)
            .Where(c => c.Person != null && (c.Person.Name.Contains(searchTerm) || c.Person.Phone.Contains(searchTerm)))
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Busca un cliente por su número de documento.
    /// </summary>
    /// <param name="documentNumber">Número de documento del cliente</param>
    /// <returns>Cliente encontrado o null</returns>
    public async Task<Client?> GetByDocumentNumberAsync(string documentNumber)
    {
        return await _context.Set<Client>()
            .Include(c => c.Person)
            .FirstOrDefaultAsync(c => c.Person != null && c.Person.Document == documentNumber);
    }
}
