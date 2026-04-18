using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaz.IBusinessData;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Client;
using MapsterMapper;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Services.Business
{
    public class ClientServices
        : ServicesBase<ClientListDto, ClientCreateDto, Client>,
        IClientServices
    {
        private readonly IMapper _mapper;
        private readonly IClientData _data;

        public ClientServices(IClientData data, IMapper mapper)
            : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientListDto>> GetClientListAsync(CancellationToken cancellationToken = default)
        {
            return await _data.GetClientListAsync(cancellationToken);
        }

        public async Task<ClientListDto> SearchByNameOrPhoneAsync(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException("El numero de telefono es requerido.");

            var client = await _data.SearchByNameOrPhoneAsync(phone);
            if (client is null)
                throw new ArgumentNullException("No se encontro ningun cliente con ese numero de telefono.");

            return _mapper.Map<ClientListDto>(client);
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
