using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;


namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Pago.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPaymentData : IData<Payment>
{
    /// <summary>
    /// CU-35: Obtiene el historial completo de pagos de una factura.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Lista de pagos ordenados cronológicamente</returns>
    Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId);

    /// <summary>
    /// CU-33: Registra un anticipo para una factura.
    /// </summary>
    /// <param name="payment">Datos del pago anticipado</param>
    /// <returns>Pago registrado</returns>
    Task<Payment> RegisterAdvancePaymentAsync(Payment payment);

    /// <summary>
    /// CU-34: Registra el pago final o total de una factura.
    /// </summary>
    /// <param name="payment">Datos del pago final</param>
    /// <returns>Pago registrado</returns>
    Task<Payment> RegisterFinalPaymentAsync(Payment payment);

    /// <summary>
    /// Obtiene la suma total de pagos realizados para una factura.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Total pagado</returns>
    Task<decimal> GetTotalPaidByInvoiceAsync(int invoiceId);
}
