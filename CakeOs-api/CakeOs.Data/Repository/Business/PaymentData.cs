using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.DTOs.Business.Payment;
using CakeOs.Entity.Enum.Payment;
using CakeOS.Entity.Domain.Business;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Pago.
/// Proporciona operaciones CRUD y métodos específicos para gestión de pagos.
/// </summary>
public class PaymentData : DataBase<Payment>, IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public override async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Set<Payment>()
            .Include(p => p.User)
                .ThenInclude(u => u.Person)
            .OrderByDescending(p => p.PaymentDate)
            .ToListAsync(ct);
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
            .Include(p => p.User)
                .ThenInclude(u => u.Person)
            .OrderByDescending(p => p.PaymentDate)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene la suma total de pagos de facturas al dia.
    /// </summary>
    /// <param name="invoiceId">Identificador de la factura</param>
    /// <returns>Total pagado</returns>
    public async Task<decimal> GetTotalPaidByDayAsync()
    {
        var start = DateTime.Today;
        var end = start.AddDays(1);

        return await _context.Set<Payment>()
            .Where(p => p.PaymentDate >= start && p.PaymentDate < end)
            .SumAsync(p => p.Amount);
    }

    public async Task<List<Payment>> GetSummaryByRangeAsync(DateTime from, DateTime to)
    {
        return await _context.Set<Payment>()
            .Where(p => p.PaymentDate >= from && p.PaymentDate <= to && p.IsActive)
            .Include(p => p.User)
                .ThenInclude(u => u.Person)
            .OrderByDescending(p => p.PaymentDate)
            .ToListAsync();
    }
}
