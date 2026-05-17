using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOs.Entity.Enum.Invoice;
using CakeOs.Entity.Enum.Payment;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Business.Invoice;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Services.Business
{
    public class InvoiceServices : ServicesBase<InvoiceListDto, InvoiceCreateDto, Invoice>, IInvoiceServices
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceData;
        private readonly IClientRepository _clientData;
        private readonly IInvoiceItemRepository _invoiceItemData;
        private readonly IPersonRepository _personData;
        private readonly IPaymentRepository _paymentData;

        /// <summary>
        /// Necesario para la utilizacion de las transaciones
        /// </summary>
        private readonly ApplicationDbContext _context;

        public InvoiceServices(
            IMapper mapper,
            IInvoiceRepository data,
            IClientRepository clientData,
            IInvoiceItemRepository invoiceItemData,
            IPersonRepository personData,
            IPaymentRepository paymentData,
            ApplicationDbContext context)
           : base(data, mapper)
        {
            _mapper = mapper;
            _invoiceData = data;
            _clientData = clientData;
            _invoiceItemData = invoiceItemData;
            _context = context;
            _personData = personData;
            _paymentData = paymentData;
        }

        public async Task<InvoiceListDto> CreateInvoiceAsync(InvoiceCreateDto dto, int userId)
        {
            if (dto.TypeDocument is null)
                throw new ArgumentException("Debes seleccionar algún tipo de documento.");
            if (dto.Document is null)
                throw new ArgumentException("El número de documento estar vacío");
            if (dto.Items is null || !dto.Items.Any())
                throw new ArgumentException("La factura debe tener al menos un ítem");

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var client = await _clientData.GetByDocumentNumberAsync(dto.Document);
                    if (client is null)
                    {
                        var person = _mapper.Map<Person>(dto);
                        var newPerson = await _personData.AddAsync(person);
                        var newClient = new Client
                        {
                            Person = person,
                            Email = dto.Email,
                            IsActive = true
                        };
                        await _clientData.AddAsync(newClient);
                        client = newClient;
                    }

                    string code = await GenerateInvoiceCodeAsync();
                    var total = dto.Items.Sum(i => i.Quantity * i.UnitPrice);                    

                    var invoice = new Invoice
                    {
                        Client = client,
                        UserId = userId,
                        Code = code,
                        Total = total,
                        OutstandingBalance = total - (dto.InitialPayment),
                        Status = InvoiceStatus.Pendiente,
                        CreatedAt = DateTime.UtcNow,
                        DeliveryDate = dto.DeliveryDate,
                        IsActive = true
                    };
                    await _invoiceData.AddAsync(invoice);

                    foreach (var item in dto.Items)
                    {
                        var invoiceItem = new InvoiceItem
                        {
                            Invoice = invoice,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                            SubTotal = item.Quantity * item.UnitPrice,
                            HasFilling = item.HasFilling,
                            FilledId = item.FilledId,
                            HasDecoration = item.HasDecoration,
                            DecorationDescription = item.DecorationDescription,
                            HasMessage = item.HasMessage,
                            Message = item.Message,
                            Status = InvoiceItemStatus.Pendiente
                        };

                        await _invoiceItemData.AddAsync(invoiceItem);
                    }

                    if(dto.HasInitialPayment)
                    {
                        PaymentType type;

                        if (dto.InitialPayment > 0 && !Enum.IsDefined(typeof(PaymentMethod), dto.PaymentMethod.Value))
                            throw new ArgumentException("Debe especificar un método de pago cuando se registra un pago inicial");

                        if (invoice.OutstandingBalance == 0)
                        {
                            type = PaymentType.PagoTotal;
                            invoice.Status = InvoiceStatus.Pagada;
                        }  
                        else
                            type = PaymentType.Abono;

                        var paymet = new Payment
                        {
                            Invoice = invoice,
                            UserId = userId,
                            Amount = dto.InitialPayment,
                            PaymentMethod = dto.PaymentMethod.Value,
                            PaymentType = type,
                            PaymentDate = DateTime.UtcNow
                        };

                        await _paymentData.AddAsync(paymet);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    var result = await _invoiceData.GetByIdWithDetailsAsync(invoice.Id);
                    return _mapper.Map<InvoiceListDto>(result);
                }
                catch
                {
                    if (transaction.GetDbTransaction().Connection is not null)
                        await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        public async Task<List<InvoiceListDto>> GetInvoicesForTodayAsync()
        {
            var invoices = await _invoiceData.GetInvoicesForTodayAsync();
            return invoices;
        }

        public async Task<InvoiceDetailDto?> GetWithDetailsAsync(int id)
        {
            if (id <= 0)
                throw new Exception("No existe ninguna factura con ese ID");

            var invoiceDetails = await _invoiceData.GetWithDetailsAsync(id);
            return invoiceDetails;
        }

        private async Task<string> GenerateInvoiceCodeAsync()
        {
            var today = DateTime.UtcNow.Date;
            var prefix = $"FAC-{today:yyyyMMdd}";

            var lastInvoice = await _invoiceData.GetLastInvoiceOfDayAsync(today);

            var consecutive = lastInvoice is null ? 1 : lastInvoice + 1;

            return $"{prefix}-{consecutive:D3}";
        }
    }
}
