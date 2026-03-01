using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Factura.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IInvoiceData : IData<Invoice>
{
    // Aquí se pueden agregar métodos específicos para Factura si es necesario
    // Por ejemplo: Task<IEnumerable<Invoice>> GetByDateRangeAsync(DateTime inicio, DateTime fin);
}
