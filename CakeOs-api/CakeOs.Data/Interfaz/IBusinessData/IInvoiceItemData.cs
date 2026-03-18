using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;


namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Item de Factura.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IInvoiceItemData : IData<InvoiceItem>
{
    /// <summary>
    /// Obtiene todos los ítems de una factura específica.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Lista de ítems de la factura</returns>
    Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(int invoiceId);

    /// <summary>
    /// CU-30: Marca un ítem como listo (cambia su estado).
    /// </summary>
    /// <param name="itemId">Identificador del ítem</param>
    /// <returns>True si se marcó como listo correctamente</returns>
    Task<bool> MarkAsReadyAsync(int itemId);

    /// <summary>
    /// Obtiene ítems de una factura con todos sus detalles (producto, parámetros).
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Lista de ítems con detalles</returns>
    Task<IEnumerable<InvoiceItem>> GetByInvoiceIdWithDetailsAsync(int invoiceId);
}
