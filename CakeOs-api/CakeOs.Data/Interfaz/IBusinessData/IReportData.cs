namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de reportes y análisis del sistema.
/// Proporciona métodos especializados para consultas complejas de reportería.
/// </summary>
public interface IReportData
{
    /// <summary>
    /// CU-36: Obtiene el resumen del día con cantidad de facturas y total vendido.
    /// </summary>
    /// <returns>Diccionario con estadísticas del día (totalInvoices, totalRevenue)</returns>
    Task<Dictionary<string, object>> GetDailySummaryAsync();

    /// <summary>
    /// CU-38: Obtiene los productos más vendidos en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <param name="topCount">Cantidad de productos a retornar</param>
    /// <returns>Lista de productos con sus cantidades vendidas</returns>
    Task<IEnumerable<Dictionary<string, object>>> GetTopSellingProductsAsync(DateTime startDate, DateTime endDate, int topCount = 10);

    /// <summary>
    /// CU-39: Obtiene los ingresos por método de pago en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Diccionario con método de pago como clave e ingreso como valor</returns>
    Task<Dictionary<string, decimal>> GetRevenueByPaymentMethodAsync(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Obtiene el total de ingresos en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Total de ingresos</returns>
    Task<decimal> GetTotalRevenueAsync(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Obtiene la cantidad total de facturas en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Cantidad de facturas</returns>
    Task<int> GetInvoiceCountAsync(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Obtiene el promedio de venta por factura en un período específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del período</param>
    /// <param name="endDate">Fecha final del período</param>
    /// <returns>Promedio de venta por factura</returns>
    Task<decimal> GetAverageSalePerInvoiceAsync(DateTime startDate, DateTime endDate);
}
