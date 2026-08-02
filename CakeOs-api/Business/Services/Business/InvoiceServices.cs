using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Business;
using CakeOs.Entity.Enum.Invoice;
using CakeOs.Entity.Enum.Payment;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Business.Invoice;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace CakeOs.Business.Services.Business
{
    public class InvoiceServices : TenantServicesBase<InvoiceListDto, InvoiceCreateDto, Invoice>, IInvoiceServices
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceData;
        private readonly IClientRepository _clientData;
        private readonly IInvoiceItemRepository _invoiceItemData;
        private readonly IInvoiceItemExtraRepository _invoiceItemExtraData;
        private readonly IPersonRepository _personData;
        private readonly IPaymentRepository _paymentData;
        private readonly ICurrentUserService _currentUserService;
        private readonly IProductRepository _productRepository;
        private readonly IFilledRepository _filledRepository;

        // Necesario para las transacciones
        private readonly ApplicationDbContext _context;

        public InvoiceServices(
            IMapper mapper,
            IInvoiceRepository data,
            IClientRepository clientData,
            IInvoiceItemRepository invoiceItemData,
            IInvoiceItemExtraRepository invoiceItemExtraData,
            IPersonRepository personData,
            IPaymentRepository paymentData,
            ILoggerFactory loggerFactory,
            ApplicationDbContext context,
            ITenantProvider tenantProvider,
            ICurrentUserService currentUserService,
            IProductRepository productRepository,
            IFilledRepository filledRepository)

           : base(data, mapper, loggerFactory, tenantProvider)
        {
            _mapper = mapper;
            _invoiceData = data;
            _clientData = clientData;
            _invoiceItemData = invoiceItemData;
            _invoiceItemExtraData = invoiceItemExtraData;
            _context = context;
            _personData = personData;
            _paymentData = paymentData;
            _currentUserService = currentUserService;
            _productRepository = productRepository;
            _filledRepository = filledRepository;
        }

        public async Task<InvoiceListDto> CreateInvoiceAsync(InvoiceCreateDto dto)
        {
            if (dto.TypeDocument is null)
                throw new ArgumentException("Debes seleccionar algún tipo de documento.");
            if (dto.Document is null)
                throw new ArgumentException("El número de documento no puede estar vacío.");
            if (dto.Items is null || !dto.Items.Any())
                throw new ArgumentException("La factura debe tener al menos un ítem.");

            var tenantId = _tenantProvider.TenantId
                ?? throw new InvalidOperationException("No se pudo determinar el TenantId.");

            var userId = _currentUserService.RequireUserId();

            _logger.LogInformation(
                "Iniciando creación de factura para documento {Document} (UserId: {UserId})",
                dto.Document, userId);

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
                        person.TenantId = tenantId;
                        await _personData.AddAsync(person);
                        var newClient = new Client
                        {
                            Person = person,
                            Email = dto.Email,
                            IsActive = true,
                            TenantId = tenantId
                        };
                        await _clientData.AddAsync(newClient);
                        client = newClient;
                    }

                    string code = await GenerateInvoiceCodeAsync();
                    var total = dto.Items.Sum(i =>
                        i.Quantity * i.UnitPrice +
                        i.Extras.Sum(e => e.Quantity * e.UnitPrice));

                    var invoice = new Invoice
                    {
                        Client = client,
                        UserId = userId,
                        Code = code,
                        Total = total,
                        OutstandingBalance = total - dto.InitialPayment,
                        Status = InvoiceStatus.Pendiente,
                        CreatedAt = DateTime.UtcNow,
                        DeliveryDate = dto.DeliveryDate,
                        IsActive = true,
                        TenantId = tenantId
                    };
                    await _invoiceData.AddAsync(invoice);

                    foreach (var itemDto in dto.Items)
                    {
                        // Validar ProductId
                        if (itemDto.ProductId <= 0)
                            throw new ArgumentException("El ProductId debe ser válido.");

                        var product = await _productRepository.GetByIdAsync(itemDto.ProductId);
                        if (product is null)
                            throw new ArgumentException($"No existe un producto con el ID {itemDto.ProductId}.");

                        // Validar FilledId si HasFilling es true
                        if (itemDto.HasFilling)
                        {
                            if (itemDto.FilledId is null || itemDto.FilledId <= 0)
                                throw new ArgumentException("Debe especificar un FilledId válido cuando HasFilling es true.");

                            var filled = await _filledRepository.GetByIdAsync(itemDto.FilledId.Value);
                            if (filled is null)
                                throw new ArgumentException($"No existe un relleno con el ID {itemDto.FilledId}.");
                        }

                        var invoiceItem = _mapper.Map<InvoiceItem>(itemDto);
                        invoiceItem.Invoice = invoice;
                        await _invoiceItemData.AddAsync(invoiceItem);

                        foreach (var extraDto in itemDto.Extras)
                        {
                            if (extraDto.ExtraId == 0)
                                throw new ArgumentException("No se encontro ese id");

                            if (extraDto.Quantity == 0)
                                throw new ArgumentException("La cantidad no puede ser igual o menor a cero");

                            if (extraDto.UnitPrice == 0)
                                throw new ArgumentException("La precio unitario no puede ser cero");

                            var invoiceItemExtra = _mapper.Map<InvoiceItemExtra>(extraDto);
                            invoiceItemExtra.InvoiceItem = invoiceItem;
                            await _invoiceItemExtraData.AddAsync(invoiceItemExtra);
                        }
                    }

                    if (dto.HasInitialPayment)
                    {
                        if (dto.InitialPayment > 0 && !Enum.IsDefined(typeof(PaymentMethod), dto.PaymentMethod!.Value))
                            throw new ArgumentException("Debe especificar un método de pago válido cuando se registra un pago inicial.");

                        var paymentType = invoice.OutstandingBalance == 0 ? PaymentType.PagoTotal : PaymentType.Abono;
                        if (paymentType == PaymentType.PagoTotal)
                            invoice.Status = InvoiceStatus.Pagada;

                        var payment = new Payment
                        {
                            Invoice = invoice,
                            UserId = userId,
                            Amount = dto.InitialPayment,
                            PaymentMethod = dto.PaymentMethod!.Value,
                            PaymentType = paymentType,
                            PaymentDate = DateTime.UtcNow,
                            TenantId = tenantId
                        };
                        await _paymentData.AddAsync(payment);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation("Factura {Code} creada exitosamente. Total: {Total}", invoice.Code, invoice.Total);

                    var result = await _invoiceData.GetByIdWithDetailsAsync(invoice.Id);
                    return _mapper.Map<InvoiceListDto>(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear factura para documento {Document}", dto.Document);
                    if (transaction.GetDbTransaction().Connection is not null)
                        await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        public async Task<List<InvoiceListDto>> GetInvoicesByRangeAsync(TimeRangeFilter range)
        {
            var invoices = await _invoiceData.GetInvoicesByRangeAsync(range);
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
