using CakeOs.Data.Base;
using CakeOS.Entity.Domain.Business;


namespace CakeOs.Data.Interfaces.Business;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Pago.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPaymentRepository : IData<Payment>
{
    /// <summary>
    /// CU-35: Obtiene el historial completo de pagos de una factura.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Lista de pagos ordenados cronológicamente</returns>
    Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId);

    /// <summary>
    /// Obtiene la suma total de pagos realizados para una factura.
    /// </summary>
    /// <returns>Total pagado</returns>
    Task<decimal> GetTotalPaidByDayAsync();
}
