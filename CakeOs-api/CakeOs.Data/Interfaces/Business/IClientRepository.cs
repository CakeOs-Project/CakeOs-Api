using CakeOs.Data.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Client;

namespace CakeOs.Data.Interfaces.Business;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Cliente.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IClientRepository : IData<Client>
{
    /// <summary>
    /// CU-14 CU-14: Listar clientes
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<List<ClientListDto>> GetClientListAsync(CancellationToken ct = default);

    /// <summary>
    /// CU-13: Busca clientes por nombre o número de teléfono.
    /// </summary>
    /// <param name="searchTerm">Término de búsqueda (nombre o teléfono)</param>
    /// <returns>Lista de clientes que coinciden con la búsqueda</returns>
    Task<IEnumerable<Client>> SearchByNameOrPhoneAsync(string searchTerm);

    
    /// <summary>
    /// Busca un cliente por su número de documento.
    /// </summary>
    /// <param name="documentNumber">Número de documento del cliente</param>
    /// <returns>Cliente encontrado o null</returns>
    Task<Client?> GetByDocumentNumberAsync(string document);

}
