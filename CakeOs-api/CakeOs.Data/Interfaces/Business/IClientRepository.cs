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
    /// CU-13: Busca un cliente por su número de documento.
    /// </summary>
    /// <param name="searchTerm">Término de búsqueda (nombre o teléfono)</param>
    /// <returns>Lista de clientes que coinciden con la búsqueda</returns>
    Task<Client?> GetByDocumentNumberAsync(string document);

}
