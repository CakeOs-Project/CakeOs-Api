using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Invoice;

namespace CakeOs.Business.Services.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con facturas.
    /// </summary>
    public class InvoiceService : BaseService<Invoice, InvoiceDetailDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de facturas.
        /// </summary>
        /// <param name="data">Repositorio de datos de facturas.</param>
        public InvoiceService(IData<Invoice> data) : base(data)
        {
        }

        /// <summary>
        /// Convierte un DTO a una entidad Invoice.
        /// </summary>
        protected override Invoice MapToEntity(InvoiceDetailDto dto)
        {
            return new Invoice
            {
                Code = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                Total = dto.Total,
                OutstandingBalance = dto.OutstandingBalance,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt,
                DeliveryDate = dto.DeliveryDate
            };
        }

        /// <summary>
        /// Actualiza una entidad Invoice existente con los datos del DTO.
        /// </summary>
        protected override void MapToEntity(InvoiceDetailDto dto, Invoice entity)
        {
            entity.Total = dto.Total;
            entity.DeliveryDate = dto.DeliveryDate;
            entity.Status = dto.Status;
            entity.OutstandingBalance = dto.OutstandingBalance;
        }

        /// <summary>
        /// Convierte una entidad Invoice a un DTO.
        /// </summary>
        protected override InvoiceDetailDto MapToDto(Invoice entity)
        {
            return new InvoiceDetailDto
            {
                Id = entity.Id,
                Code = entity.Code,
                ClientFullName = entity.Client?.LastName + " " + entity.Client?.Name ?? string.Empty,
                ClientPhone = entity.Client?.Phone ?? string.Empty,
                ClientEmail = entity.Client?.Email,
                Total = entity.Total,
                OutstandingBalance = entity.OutstandingBalance,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt,
                DeliveryDate = entity.DeliveryDate,
                CreatedByFullName = entity.User?.Persona?.Name + " " + entity.User?.Persona?.LastName ?? string.Empty,
                Items = new List<InvoiceItemDetailDto>(),
                Payments = new List<PaymentListDto>()
            };
        }
    }
}

