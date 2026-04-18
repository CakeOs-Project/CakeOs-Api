using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;

namespace CakeOs.Business.Services.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con pagos.
    /// </summary>
    public class PaymentService : BaseService<Payment, PaymentListDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de pagos.
        /// </summary>
        /// <param name="data">Repositorio de datos de pagos.</param>
        public PaymentService(IData<Payment> data) : base(data)
        {
        }

        /// <summary>
        /// Convierte un DTO a una entidad Payment.
        /// </summary>
        protected override Payment MapToEntity(PaymentListDto dto)
        {
            return new Payment
            {
                Amount = dto.Amount,
                PaymentDate = dto.PaymentDate,
                PaymentMethod = dto.PaymentMethod
            };
        }

        /// <summary>
        /// Actualiza una entidad Payment existente con los datos del DTO.
        /// </summary>
        protected override void MapToEntity(PaymentListDto dto, Payment entity)
        {
            entity.Amount = dto.Amount;
            entity.PaymentDate = dto.PaymentDate;
            entity.PaymentMethod = dto.PaymentMethod;
        }

        /// <summary>
        /// Convierte una entidad Payment a un DTO.
        /// </summary>
        protected override PaymentListDto MapToDto(Payment entity)
        {
            return new PaymentListDto
            {
                Id = entity.Id,
                Amount = entity.Amount,
                PaymentDate = entity.PaymentDate,
                PaymentMethod = entity.PaymentMethod,
                PaymentType = "Pago",
                RegisteredByFullName = entity.User?.Persona?.Name + " " + entity.User?.Persona?.LastName ?? string.Empty
            };
        }
    }
}
