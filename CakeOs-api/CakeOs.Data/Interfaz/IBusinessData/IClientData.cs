using CakeOs.Data.Interfaz.IData;

using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Cliente.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IClientData : IData<Client>
{
    /// <summary>
    /// CU-13: Busca clientes por nombre o número de teléfono.
    /// </summary>
    /// <param name="searchTerm">Término de búsqueda (nombre o teléfono)</param>
    /// <returns>Lista de clientes que coinciden con la búsqueda</returns>
    Task<IEnumerable<Client>> SearchByNameOrPhoneAsync(string searchTerm);

    /// <summary>
    /// CU-14: Obtiene todos los clientes activos del sistema.
    /// </summary>
    /// <returns>Lista de clientes activos</returns>
    Task<IEnumerable<Client>> GetActiveClientsAsync();

    /// <summary>
    /// Busca un cliente por su número de documento.
    /// </summary>
    /// <param name="documentNumber">Número de documento del cliente</param>
    /// <returns>Cliente encontrado o null</returns>
    Task<Client?> GetByDocumentNumberAsync(string documentNumber);
}
