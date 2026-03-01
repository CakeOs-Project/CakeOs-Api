using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Pago.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPaymentData : IData<Payment>
{
    // Aquí se pueden agregar métodos específicos para Pago si es necesario
    // Por ejemplo: Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId);
}
