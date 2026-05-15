using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Business;
using CakeOS.Entity.Domain.Business;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para reportes y análisis.
/// Proporciona métodos especializados para consultas complejas de reportería.
/// </summary>
public class ReportData : IReportRepository
{
    private readonly ApplicationDbContext _context;

    public ReportData(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// CU-36: Obtiene el resumen del día con cantidad de facturas y total vendido.
    /// </summary>
    /// <returns>Diccionario con estadísticas del día (totalInvoices, totalRevenue)</returns>
    public async Task<Dictionary<string, object>> GetDailySummaryAsync()
    {
        var today = DateTime.UtcNow.Date;
        
        var invoices = await _context.Set<Invoice>()
            .Where(i => i.CreatedAt.Date == today)
            .ToListAsync();

        var totalInvoices = invoices.Count;
        var totalRevenue = invoices.Sum(i => i.Total);

        return new Dictionary<string, object>
        {
            { "totalInvoices", totalInvoices },
            { "totalRevenue", totalRevenue },
            { "date", today }
        };
    }

    /// <summary>
    /// CU-38: Obtiene los productos más vendidos en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <param name="topCount">Cantidad de productos a retornar</param>
    /// <returns>Lista de productos con sus cantidades vendidas</returns>
    public async Task<IEnumerable<Dictionary<string, object>>> GetTopSellingProductsAsync(
        DateTime startDate, DateTime endDate, int topCount = 10)
    {
        var topProducts = await _context.Set<InvoiceItem>()
            .Where(ii => ii.Invoice.CreatedAt >= startDate && ii.Invoice.CreatedAt <= endDate)
            .GroupBy(ii => ii.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                Quantity = g.Sum(ii => ii.Quantity),
                TotalAmount = g.Sum(ii => ii.Quantity * ii.UnitPrice)
            })
            .OrderByDescending(g => g.Quantity)
            .Take(topCount)
            .ToListAsync();

        var result = new List<Dictionary<string, object>>();
        foreach (var product in topProducts)
        {
            var productEntity = await _context.Set<Product>().FindAsync(product.ProductId);
            result.Add(new Dictionary<string, object>
            {
                { "productId", product.ProductId },
                { "productName", productEntity?.Name ?? "Unknown" },
                { "quantity", product.Quantity },
                { "totalAmount", product.TotalAmount }
            });
        }

        return result;
    }

    /// <summary>
    /// CU-39: Obtiene los ingresos por método de pago en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Diccionario con método de pago como clave e ingreso como valor</returns>
    public async Task<Dictionary<string, decimal>> GetRevenueByPaymentMethodAsync(
        DateTime startDate, DateTime endDate)
    {
        var payments = await _context.Set<Payment>()
            .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
            .GroupBy(p => p.PaymentMethod)
            .Select(g => new
            {
                PaymentMethod = g.Key,
                Amount = g.Sum(p => p.Amount)
            })
            .ToListAsync();

        return payments.ToDictionary(
                p => p.PaymentMethod.ToString(),
                p => p.Amount
            );
    }

    /// <summary>
    /// Obtiene el total de ingresos en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Total de ingresos</returns>
    public async Task<decimal> GetTotalRevenueAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Set<Invoice>()
            .Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate)
            .SumAsync(i => i.Total);
    }

    /// <summary>
    /// Obtiene la cantidad total de facturas en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Cantidad de facturas</returns>
    public async Task<int> GetInvoiceCountAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Set<Invoice>()
            .Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate)
            .CountAsync();
    }

    /// <summary>
    /// Obtiene el promedio de venta por factura en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Promedio de venta por factura</returns>
    public async Task<decimal> GetAverageSalePerInvoiceAsync(DateTime startDate, DateTime endDate)
    {
        var invoices = await _context.Set<Invoice>()
            .Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate)
            .ToListAsync();

        if (invoices.Count == 0) return 0;

        return invoices.Sum(i => i.Total) / invoices.Count;
    }
}
