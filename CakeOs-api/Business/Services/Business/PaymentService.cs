using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.DTOs.Transversal;
using CakeOs.Entity.Enum.Payment;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;
using MapsterMapper;

namespace CakeOs.Business.Services.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con pagos.
    /// </summary>
    public class PaymentService : ServicesBase<PaymentListDto, PaymentCreateDto, Payment>, IPaymentServices
    {
        private readonly IPaymentRepository _repository;
        private readonly IInvoiceRepository _invoice;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository data, IInvoiceRepository invoice, IMapper mapper) : base(data, mapper)
        {
            _repository = data;
            _invoice = invoice;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentListDto>> GetByInvoiceIdAsync(int invoiceId)
        {
            var payment = await _repository.GetByInvoiceIdAsync(invoiceId);
            return _mapper.Map<IEnumerable<PaymentListDto>>(payment);
        }

        public async Task<PaymentListDto> RegisterPaymentAsync(PaymentCreateDto dto, int userId)
        {
            var payment = _mapper.Map<Payment>(dto);

            var invoice = await _invoice.GetByIdAsync(payment.InvoiceId);
            if (invoice == null) throw new ArgumentNullException("La factura no existe.");

            if (payment.Amount > invoice.OutstandingBalance)
                throw new ArgumentException("El monto excede el saldo pendiente.");

            payment.PaymentType = (payment.Amount == invoice.OutstandingBalance)
                                  ? PaymentType.PagoFinal
                                  : PaymentType.Abono;

            invoice.OutstandingBalance -= payment.Amount;
            await _invoice.UpdateAsync(invoice);

            payment.UserId = userId;
            var result = await _repository.AddAsync(payment);

            if (result is null)
                throw new ArgumentNullException("Error al guardar el pago.");

            await _repository.SaveChangesAsync();
            await _invoice.SaveChangesAsync();

            return _mapper.Map<PaymentListDto>(result);

        }

        public async Task<decimal> GetTotalPaidByDayAsync()
        {
            var result = await _repository.GetTotalPaidByDayAsync();

            return result;
        }
    }
}