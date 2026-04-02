using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Client;

namespace CakeOs.Business.Services.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con clientes.
    /// </summary>
    public class ClientService : BaseService<Client, ClientListDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de clientes.
        /// </summary>
        /// <param name="data">Repositorio de datos de clientes.</param>
        public ClientService(IData<Client> data) : base(data)
        {
        }

        /// <summary>
        /// Convierte un DTO a una entidad Client.
        /// </summary>
        protected override Client MapToEntity(ClientListDto dto)
        {
            return new Client
            {
                Email = dto.Email ?? string.Empty
            };
        }

        /// <summary>
        /// Actualiza una entidad Client existente con los datos del DTO.
        /// </summary>
        protected override void MapToEntity(ClientListDto dto, Client entity)
        {
            entity.Email = dto.Email ?? entity.Email;
        }

        /// <summary>
        /// Convierte una entidad Client a un DTO.
        /// </summary>
        protected override ClientListDto MapToDto(Client entity)
        {
            return new ClientListDto
            {
                Id = entity.Id,
                FullName = entity.Person?.Name + " " + entity.Person?.LastName ?? string.Empty,
                Phone = entity.Person?.Phone ?? string.Empty,
                Email = entity.Email,
                IsActive = entity.IsActive
            };
        }
    }
}
