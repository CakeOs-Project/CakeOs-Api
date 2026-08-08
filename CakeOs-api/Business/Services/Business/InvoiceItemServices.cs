using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.DTOs.Transversal;
using CakeOs.Entity.Enum.Invoice;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.InvoiceItem;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeOs.Business.Exceptions;

namespace CakeOs.Business.Services.Business
{
    public class InvoiceItemServices : ServicesBase<InvoiceItemDetailDto, InvoiceItemCreateDto, InvoiceItem>, IInvoiceItemServices
    {
        private readonly IInvoiceItemRepository _item;
        private readonly IInvoiceRepository _invoice;
        private readonly IMapper _mapper;
        private readonly ILogger<InvoiceItemServices> _logger;

        public InvoiceItemServices(IInvoiceItemRepository item, IInvoiceRepository invoice, IMapper mapper, ILoggerFactory loggerFactory)
            : base(item, mapper, loggerFactory)
        {
            _item = item;
            _invoice = invoice;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<InvoiceItemServices>();
        }

        public async Task<ResponseDto> MarkAsReadyAsync(int itemId)
        {
            try
            {
                // Validación 1: Validar que el ID sea válido
                if (itemId <= 0)
                {
                    _logger.LogWarning("Intento de marcar item con ID inválido: {ItemId}", itemId);
                    throw new ArgumentOutOfRangeException(nameof(itemId), "El id del ítem debe ser mayor a 0.");
                }

                // Validación 2: Obtener el item
                var item = await _item.GetByIdAsync(itemId);
                if (item is null)
                {
                    _logger.LogWarning("Intento de marcar item inexistente: {ItemId}", itemId);
                    return ResponseDto.Fail("El ítem no existe.");
                }

                // Validación 3: Verificar que el item está activo
                if (!item.IsActive)
                {
                    _logger.LogWarning("Intento de marcar item inactivo como listo: {ItemId}", itemId);
                    return ResponseDto.Fail("No se puede actualizar un ítem inactivo.");
                }

                // Validación 4: Verificar que ya no está marcado como listo
                if (item.Status == InvoiceItemStatus.Listo)
                {
                    _logger.LogInformation("Item ya estaba marcado como listo: {ItemId}", itemId);
                    return ResponseDto.Fail("El ítem ya está marcado como listo.");
                }

                // Validación 5: Obtener la factura y validar que existe
                var invoice = await _invoice.GetByIdAsync(item.InvoiceId);
                if (invoice is null)
                {
                    _logger.LogError("Factura asociada al item no existe: {InvoiceId}", item.InvoiceId);
                    return ResponseDto.Fail("La factura asociada al ítem no existe.");
                }

                // Validación 6: Verificar que la factura está activa
                if (!invoice.IsActive)
                {
                    _logger.LogWarning("Intento de actualizar item de factura inactiva: {InvoiceId}", invoice.Id);
                    return ResponseDto.Fail("No se puede actualizar ítems de una factura inactiva.");
                }

                // Validación 7: Verificar que la factura está en estado válido para actualización
                // Las facturas deben estar en estado "Pendiente" para permitir cambios
                if (invoice.Status != InvoiceStatus.Pendiente)
                {
                    _logger.LogWarning("Intento de actualizar item de factura en estado inválido: {InvoiceId}, Estado: {Status}", 
                        invoice.Id, invoice.Status);
                    return ResponseDto.Fail("No se puede actualizar ítems de una factura que ya está lista o pagada.");
                }

                // Validación 8: Marcar el item como listo
                item.Status = InvoiceItemStatus.Listo;
                await _item.SaveChangesAsync();
                _logger.LogInformation("Item marcado como listo: {ItemId}", itemId);

                // Validación 9: Verificar si todos los items de la factura están listos
                var allReady = await _item.AllItemReady(item.InvoiceId);

                if (allReady)
                {
                    // Validación 10: Si todos están listos, actualizar estado de la factura
                    invoice.Status = InvoiceStatus.Lista;
                    await _invoice.SaveChangesAsync();
                    _logger.LogInformation("Factura marcada como lista (todos sus ítems están listos): {InvoiceId}", invoice.Id);
                }

                return ResponseDto.Ok("Ítem marcado como listo correctamente.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogError(ex, "Error de validación al marcar item como listo");
                return ResponseDto.Fail($"Error de validación: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al marcar item como listo: {ItemId}", itemId);
                return ResponseDto.Fail("Error inesperado al procesar la solicitud.");
            }
        }
    }
}

