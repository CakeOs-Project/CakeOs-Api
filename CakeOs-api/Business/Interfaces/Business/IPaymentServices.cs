using CakeOs.Business.Base;
using CakeOs.Entity.DTOs.Business.Payment;
using CakeOs.Entity.DTOs.Transversal;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Interfaces.Business
{
    public interface IPaymentServices : IServices<PaymentListDto, PaymentCreateDto, Payment>
    {
        Task<IEnumerable<PaymentListDto>> GetByInvoiceIdAsync(int invoiceId);

        /// <summary>
        /// CU-33 y CU-34: Registra un anticipo para una factura.
        /// </summary>
        /// <param name="payment">Datos del pago anticipado</param>
        /// <returns>Pago registrado</returns>
        Task<PaymentListDto> RegisterPaymentAsync(PaymentCreateDto payment);

        /// <summary>
        /// Obtiene la suma total de pagos realizados para una factura.
        /// </summary>
        /// <returns>Total pagado</returns>
        Task<decimal> GetTotalPaidByDayAsync();

        Task<PaymentSummaryDto> GetDailySummaryAsync(DateTime date);
        Task<PaymentSummaryDto> GetWeeklySummaryAsync(DateTime date);
        Task<PaymentSummaryDto> GetMonthlySummaryAsync(DateTime date);
        Task<PaymentSummaryDto> GetCustomSummaryAsync(DateTime from, DateTime to);
    }
}
