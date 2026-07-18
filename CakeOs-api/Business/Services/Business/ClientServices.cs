using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Data.Repository.BusinessData;
using CakeOs.Entity.Context;
using CakeOs.Entity.DTOs.Transversal;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Business.Client;
using CakeOS.Entity.DTOs.Business.Invoice;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Services.Business
{
    public class ClientServices
        : TenantServicesBase<ClientListDto, ClientCreateDto, Client>,
        IClientServices
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _data;
        private readonly IPersonRepository _person;
        private readonly ApplicationDbContext _context;

        public ClientServices(IClientRepository data, IPersonRepository person, IMapper mapper, ILoggerFactory loggerFactory, ApplicationDbContext context, ITenantProvider tenantProvider)
            : base(data, mapper, loggerFactory, tenantProvider)
        {
            _data = data;
            _mapper = mapper;
            _person = person;
            _context = context;
        }

        public override async Task<ClientListDto> CreateAsync(ClientCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Document))
                throw new ArgumentNullException("El numero de documento es requerido.");

            if (string.IsNullOrWhiteSpace(dto.TypeDocument))
                throw new ArgumentNullException("El tipo de documento es requerido.");

            if (string.IsNullOrWhiteSpace(dto.Phone))
                throw new ArgumentNullException("El numero de telefono es requerido.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentNullException("Los nombres son requerido.");

            if (string.IsNullOrWhiteSpace(dto.LastName))
                throw new ArgumentNullException("Los apellidos son requerido.");

            var tenantId = _tenantProvider.TenantId
                ?? throw new InvalidOperationException("No se pudo determinar el TenantId.");

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var existClient = await _data.GetByDocumentNumberAsync(dto.Document);

                    if (existClient is not null)
                        throw new Exception("Ya existe un cliente con ese documento");

                    var person = new Person
                    {
                        Name = dto.Name,
                        LastName = dto.LastName,
                        TypeDocument = dto.TypeDocument,
                        Document = dto.Document,
                        Phone = dto.Phone,
                        Address = dto.Address,
                        CreateAt = DateTime.UtcNow,
                        TenantId = tenantId
                    };

                    var newPerson = await _person.AddAsync(person);

                    var client = new Client
                    {
                        Person = newPerson,
                        Email = dto.Email,
                        TenantId = tenantId
                    };

                    var newClient = await _data.AddAsync(client);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return _mapper.Map<ClientListDto>(newClient);
                }
                catch
                {
                    if (transaction.GetDbTransaction().Connection is not null)
                        await transaction.RollbackAsync();
                    throw;
                }

            });
        }

        public override async Task<ResponseDto> UpdateAsync(int id, ClientCreateDto dto)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("El id debe ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentNullException("Los nombres son requeridos.");
            if (string.IsNullOrWhiteSpace(dto.LastName))
                throw new ArgumentNullException("Los apellidos son requeridos.");
            if (string.IsNullOrWhiteSpace(dto.Phone))
                throw new ArgumentNullException("El número de teléfono es requerido.");

            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var client = await _data.GetByIdAsync(id);
                    if (client is null)
                        throw new Exception("No existe un cliente con ese id.");

                    _mapper.Map(dto, client.Person);
                    client.Email = dto.Email;

                    await _person.UpdateAsync(client.Person);
                    await _data.UpdateAsync(client);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return ResponseDto.Ok("Cliente actualizado correctamente.");
                }
                catch
                {
                    if (transaction.GetDbTransaction().Connection is not null)
                        await transaction.RollbackAsync();
                    throw;
                }
            });
        }


        public async Task<ClientListDto?> GetByDocumentNumberAsync(string document)
        {
            if (string.IsNullOrWhiteSpace(document))
                throw new ArgumentNullException("El numero de documento es requerido.");

            var client = await _data.GetByDocumentNumberAsync(document);
            if (client is null)
                throw new ArgumentNullException("No se encontro ningun cliente con ese numero de documento.");

            return _mapper.Map<ClientListDto?>(client);
        }
    }
}
