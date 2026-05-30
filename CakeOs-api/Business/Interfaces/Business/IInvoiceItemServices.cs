using CakeOs.Business.Base;
using CakeOs.Entity.DTOs.Transversal;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.InvoiceItem;

namespace CakeOs.Business.Interfaces.Business
{
    public interface IInvoiceItemServices : IServices<InvoiceItemDetailDto,InvoiceItemCreateDto, Invoice>
    {
        Task<ResponseDto> MarkAsReadyAsync(int itemId);
    }
}
