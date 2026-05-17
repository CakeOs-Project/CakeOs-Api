using CakeOs.Business.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Client;

namespace CakeOs.Business.Interfaces.Business
{
    public interface IClientServices : IServices<ClientListDto,ClientCreateDto,Client>
    {
        Task<ClientListDto?> GetByDocumentNumberAsync(string document);
    }
}
