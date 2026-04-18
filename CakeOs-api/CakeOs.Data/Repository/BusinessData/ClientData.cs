using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Client;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Cliente.
/// Proporciona operaciones CRUD y métodos de búsqueda específicos.
/// </summary>
public class ClientData : Data<Client>, IClientData
{
    private readonly ApplicationDbContext _context;

    public ClientData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<ClientListDto>> GetClientListAsync(CancellationToken cancellationToken = default)
    {
        string query = """
           SELECT TOP (1000) 
              c.[Id],
              p.Name + ' ' + p.LastName as FullName,
              p.[TypeDocument],
              p.[Document],
              p.Phone,
              c.[Email],
              c.[IsActive]
          FROM Client c
          INNER JOIN Person p ON c.PersonId = p.Id
          WHERE c.IsActive = 1;
         """;

        return await _context.Set<ClientListDto>()
            .FromSqlRaw(query)
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
            .FirstOrDefaultAsync(c => c.Person != null && c.Email == documentNumber);
    }
}
