using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Factura.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IInvoiceData : IData<Invoice>
{
    /// <summary>
    /// CU-27: Obtiene todas las facturas creadas el día actual.
    /// </summary>
    /// <returns>Lista de facturas del día</returns>
    Task<IEnumerable<Invoice>> GetInvoicesForTodayAsync();

    /// <summary>
    /// CU-28: Obtiene facturas por fecha de entrega específica.
    /// </summary>
    /// <param name="deliveryDate">Fecha de entrega a buscar</param>
    /// <returns>Lista de facturas con esa fecha de entrega</returns>
    Task<IEnumerable<Invoice>> GetByDeliveryDateAsync(DateTime deliveryDate);

    /// <summary>
    /// CU-29: Obtiene una factura con todos sus detalles (incluye ítems, pagos, cliente).
    /// </summary>
    /// <param name="id">Identificador de la factura</param>
    /// <returns>Factura con todos sus detalles o null</returns>
    Task<Invoice?> GetWithDetailsAsync(int id);

    /// <summary>
    /// CU-37: Obtiene facturas en un rango de fechas específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del rango</param>
    /// <param name="endDate">Fecha final del rango</param>
    /// <returns>Lista de facturas en el rango</returns>
    Task<IEnumerable<Invoice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Obtiene todas las facturas de un cliente específico.
    /// </summary>
    /// <param name="clientId">Identificador del cliente</param>
    /// <returns>Lista de facturas del cliente</returns>
    Task<IEnumerable<Invoice>> GetByClientIdAsync(int clientId);

    /// <summary>
    /// CU-26: Cambia el estado de una factura a cancelada.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>True si se canceló correctamente</returns>
    Task<bool> CancelInvoiceAsync(int invoiceId);

    /// <summary>
    /// CU-32: Actualiza el estado de una factura.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <param name="newStatus">Nuevo estado</param>
    /// <returns>True si se actualizó correctamente</returns>
    Task<bool> UpdateStatusAsync(int invoiceId, string newStatus);
}
