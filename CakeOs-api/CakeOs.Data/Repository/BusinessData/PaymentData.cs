using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.Business;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Pago.
/// Proporciona operaciones CRUD y métodos específicos para gestión de pagos.
/// </summary>
public class PaymentData : Data<Payment>, IPaymentData
{
    private readonly ApplicationDbContext _context;

    public PaymentData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// CU-35: Obtiene el historial completo de pagos de una factura.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Lista de pagos ordenados cronológicamente</returns>
    public async Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId)
    {
        return await _context.Set<Payment>()
            .Where(p => p.InvoiceId == invoiceId)
            .OrderByDescending(p => p.PaymentDate)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// CU-33: Registra un anticipo para una factura.
    /// </summary>
    /// <param name="payment">Datos del pago anticipado</param>
    /// <returns>Pago registrado</returns>
    public async Task<Payment> RegisterAdvancePaymentAsync(Payment payment)
    {
        payment.PaymentType = "Advance";
        return await AddAsync(payment);
    }

    /// <summary>
    /// CU-34: Registra el pago final o total de una factura.
    /// </summary>
    /// <param name="payment">Datos del pago final</param>
    /// <returns>Pago registrado</returns>
    public async Task<Payment> RegisterFinalPaymentAsync(Payment payment)
    {
        payment.PaymentType = "Final";
        return await AddAsync(payment);
    }

    /// <summary>
    /// Obtiene la suma total de pagos realizados para una factura.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Total pagado</returns>
    public async Task<decimal> GetTotalPaidByInvoiceAsync(int invoiceId)
    {
        return await _context.Set<Payment>()
            .Where(p => p.InvoiceId == invoiceId)
            .SumAsync(p => p.Amount);
    }
}
