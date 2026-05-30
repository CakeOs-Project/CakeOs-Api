using CakeOs.Data.Base;
using CakeOS.Entity.Domain.Business;


namespace CakeOs.Data.Interfaces.Business;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Item de Factura.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IInvoiceItemRepository : IData<InvoiceItem>
{

    /// <summary>
    /// CU-30: Marca un ítem como listo (cambia su estado).
    /// </summary>
    /// <param name="itemId">Identificador del ítem</param>
    /// <returns>True si se marcó como listo correctamente</returns>
    Task<bool> MarkAsReadyAsync(int itemId);

    /// <summary>
    /// CU-31 — verificar si todos los ítems están listos
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    Task<bool> AllItemReady(int InvoiceId);

    /// <summary>
    /// Obtiene ítems de una factura con todos sus detalles (producto, parámetros).
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Lista de ítems con detalles</returns>
    //Task<IEnumerable<InvoiceItem>> GetByInvoiceIdWithDetailsAsync(int invoiceId);
}
