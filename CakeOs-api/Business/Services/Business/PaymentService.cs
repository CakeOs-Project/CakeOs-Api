using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.DTOs.Business.Payment;
using CakeOs.Entity.Enum.Payment;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Services.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con pagos.
    /// </summary>
    public class PaymentService : TenantServicesBase<PaymentListDto, PaymentCreateDto, Payment>, IPaymentServices
    {
        private readonly IPaymentRepository _repository;
        private readonly IInvoiceRepository _invoice;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        // Necesario para las transacciones
        private readonly ApplicationDbContext _context;

        public PaymentService(
            IPaymentRepository data, 
            IInvoiceRepository invoice, 
            IMapper mapper, 
            ILoggerFactory loggerFactory, 
            ITenantProvider tenantProvider,
            ICurrentUserService currentUserService,
            ApplicationDbContext context)
            : base(data, mapper, loggerFactory, tenantProvider)
        {
            _repository = data;
            _invoice = invoice;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<IEnumerable<PaymentListDto>> GetByInvoiceIdAsync(int invoiceId)
        {
            var payment = await _repository.GetByInvoiceIdAsync(invoiceId);
            return _mapper.Map<IEnumerable<PaymentListDto>>(payment);
        }

        public async Task<PaymentListDto> RegisterPaymentAsync(PaymentCreateDto dto)
        {
            var tenantId = _tenantProvider.TenantId
                ?? throw new InvalidOperationException("No se pudo determinar el TenantId.");
            var userId = _currentUserService.RequireUserId();

            if (dto.Amount <= 0)
                throw new ArgumentException("El monto del pago debe ser mayor a cero.");

            var payment = _mapper.Map<Payment>(dto);
            payment.TenantId = tenantId;

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var invoice = await _invoice.GetByIdAsync(payment.InvoiceId);
                    if (invoice is null)
                        throw new InvalidOperationException("La factura no existe.");


                    var decremented = await _invoice.TryDecrementOutstandingBalanceAsync(
                        payment.InvoiceId, tenantId, payment.Amount);

                    if (!decremented)
                        throw new ArgumentException("El monto excede el saldo pendiente.");

                    var updatedBalance = invoice.OutstandingBalance - payment.Amount;

                    if (updatedBalance == 0)
                    {
                        payment.PaymentType = PaymentType.PagoFinal;
                        await _invoice.MarkAsPaidAsync(payment.InvoiceId);
                    }
                    else
                    {
                        payment.PaymentType = PaymentType.Abono;
                    }

                    payment.UserId = userId;
                    var result = await _repository.AddAsync(payment);

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return _mapper.Map<PaymentListDto>(result);
                }
                catch
                {
                    if (transaction.GetDbTransaction().Connection is not null)
                        await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        public async Task<decimal> GetTotalPaidByDayAsync()
        {
            var result = await _repository.GetTotalPaidByDayAsync();

            return result;
        }

        public async Task<PaymentSummaryDto> GetDailySummaryAsync(DateTime date)
        {
            var from = date.Date;
            var to = date.Date.AddDays(1).AddTicks(-1);
            var payment = await _repository.GetSummaryByRangeAsync(from, to);

            return new PaymentSummaryDto
            {
                From = from,
                To = to,
                Total = payment.Sum(p => p.Amount),
                PaymentCount = payment.Count,
                Payments = _mapper.Map<IEnumerable<PaymentListDto>>(payment)
            };
        }

        public async Task<PaymentSummaryDto> GetWeeklySummaryAsync(DateTime date)
        {
            var from = date.Date.AddDays(-(int)date.DayOfWeek);
            var to = from.AddDays(7).AddTicks(-1);
            var payment = await _repository.GetSummaryByRangeAsync(from, to);

            return new PaymentSummaryDto
            {
                From = from,
                To = to,
                Total = payment.Sum(p => p.Amount),
                PaymentCount = payment.Count,
                Payments = _mapper.Map<IEnumerable<PaymentListDto>>(payment)
            };
        }

        public async Task<PaymentSummaryDto> GetMonthlySummaryAsync(DateTime date)
        {
            var from = new DateTime(date.Year, date.Month, 1);
            var to = from.AddMonths(1).AddTicks(-1);
            var payment = await _repository.GetSummaryByRangeAsync(from, to);

            return new PaymentSummaryDto
            {
                From = from,
                To = to,
                Total = payment.Sum(p => p.Amount),
                PaymentCount = payment.Count,
                Payments = _mapper.Map<IEnumerable<PaymentListDto>>(payment)
            };
        }

        public async Task<PaymentSummaryDto> GetCustomSummaryAsync(DateTime from, DateTime to)
        {
            if (from > to) throw new ArgumentException("La fecha inicio no puede ser mayor a la fecha fin.");
            var payment = await _repository.GetSummaryByRangeAsync(from, to);

            return new PaymentSummaryDto
            {
                From = from,
                To = to,
                Total = payment.Sum(p => p.Amount),
                PaymentCount = payment.Count,
                Payments = _mapper.Map<IEnumerable<PaymentListDto>>(payment)
            };
        }
    }
}