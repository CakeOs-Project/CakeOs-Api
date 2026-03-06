using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Item de Factura.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IInvoiceItemData : IData<InvoiceItem>
{
    // Aquí se pueden agregar métodos específicos para Item de Factura si es necesario
    // Por ejemplo: Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(int invoiceId);
}
