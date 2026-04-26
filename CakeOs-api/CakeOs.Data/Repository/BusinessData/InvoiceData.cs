using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOs.Entity.Enum;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Factura.
/// Proporciona operaciones CRUD y métodos específicos para búsquedas y reportes.
/// </summary>
public class InvoiceData : Data<Invoice>, IInvoiceData
{
    private readonly ApplicationDbContext _context;

    public InvoiceData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// CU-27: Obtiene todas las facturas creadas el día actual.
    /// </summary>
    /// <returns>Lista de facturas del día</returns>
    public async Task<List<InvoiceListDto>> GetInvoicesForTodayAsync()
    {
        var start = DateTime.Today;
        var end = start.AddDays(1);

        return await _context.Set<Invoice>()
            .Include(i => i.Client)
                .ThenInclude(c => c.Person)
            .Where(i => i.DeliveryDate >= start && i.DeliveryDate < end)
            .Select(i => new InvoiceListDto
            {
                Id = i.Id,
                Code = i.Code,
                FullName = i.Client.Person.Name + " " + i.Client.Person.LastName,
                DeliveryDate = i.DeliveryDate,
                Status = i.Status,
                OutstandingBalance = i.OutstandingBalance,
                Total = i.Total
            })
            .ToListAsync();
    }

    /// <summary>
    /// CU-28: Obtiene facturas por fecha de entrega específica.
    /// </summary>
    /// <param name="deliveryDate">Fecha de entrega a buscar</param>
    /// <returns>Lista de facturas con esa fecha de entrega</returns>
    public async Task<IEnumerable<Invoice>> GetByDeliveryDateAsync(DateTime deliveryDate)
    {
        var searchDate = deliveryDate.Date;
        return await _context.Set<Invoice>()
            .Where(i => i.DeliveryDate.Date == searchDate)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// CU-29: Obtiene una factura con todos sus detalles (incluye ítems, pagos, cliente).
    /// </summary>
    /// <param name="id">Identificador de la factura</param>
    /// <returns>Factura con todos sus detalles o null</returns>
    public async Task<Invoice?> GetWithDetailsAsync(int id)
    {
        return await _context.Set<Invoice>()
            .Include(i => i.Client)
            .Include(i => i.InvoiceItems)
            .Include(i => i.Payments)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    /// <summary>
    /// CU-37: Obtiene facturas en un rango de fechas específico.
    /// </summary>
    /// <param name="startDate">Fecha inicial del rango</param>
    /// <param name="endDate">Fecha final del rango</param>
    /// <returns>Lista de facturas en el rango</returns>
    public async Task<IEnumerable<Invoice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Set<Invoice>()
            .Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene todas las facturas de un cliente específico.
    /// </summary>
    /// <param name="clientId">Identificador del cliente</param>
    /// <returns>Lista de facturas del cliente</returns>
    public async Task<IEnumerable<Invoice>> GetByClientIdAsync(int clientId)
    {
        return await _context.Set<Invoice>()
            .Where(i => i.ClientId == clientId)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// CU-26: Cambia el estado de una factura a cancelada.
    /// </summary>
    /// <param name="id">Identificador de la factura</param>
    /// <returns>True si se canceló correctamente</returns>
    public async Task<bool> CancelInvoiceAsync(int id)
    {
        var invoice = await _context.Set<Invoice>().FindAsync(id);
        if (invoice == null) return false;

        invoice.Status = InvoiceStatus.Cancelada;
        _context.Set<Invoice>().Update(invoice);
        return true;
    }

    /// <summary>
    /// Cambia el estado de una factura.
    /// </summary>
    /// <param name="id">Identificador de la factura</param>
    /// <param name="status">Nuevo estado</param>
    /// <returns>True si se actualizó correctamente</returns>
    public async Task<bool> UpdateStatusAsync(int id, InvoiceStatus status)
    {
        var invoice = await _context.Set<Invoice>().FindAsync(id);
        if (invoice == null) return false;

        invoice.Status = status;
        _context.Set<Invoice>().Update(invoice);
        return true;
    }

    /// <summary>
    /// Me trea la informacion basica de la factura y el cliente
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<InvoiceListDto?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Set<Invoice>()
        .Where(i => i.Id == id)
        .Select(i => new InvoiceListDto
        {
            Id = i.Id,
            Code = i.Code,
            FullName = i.Client.Person.Name + " " + i.Client.Person.LastName,
            DeliveryDate = i.DeliveryDate,
            Status = i.Status,
            OutstandingBalance = i.OutstandingBalance,
            Total = i.Total,
        })
        .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Me trae el ultimo registro creado en la fecha que se le pasa para luego generar un code
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public async Task<int?> GetLastInvoiceOfDayAsync(DateTime date)
    {
        var prefix = $"FAC-{date:yyyyMMdd}";

        var last = await _context.Set<Invoice>()
            .Where(i => i.Code.StartsWith(prefix))
            .OrderByDescending(i => i.Code)
            .Select(i => i.Code)
            .FirstOrDefaultAsync();

        if (last is null) return null;

        var parts = last.Split('-');
        return int.Parse(parts[^1]);
    }
}
