using CakeOs.Business.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Invoice;

namespace CakeOs.Business.Interfaces.Business
{
    public interface IInvoiceServices : IServices<InvoiceListDto,InvoiceCreateDto,Invoice>
    {
        Task<InvoiceListDto> CreateInvoiceAsync(InvoiceCreateDto dto, int userId);
        Task<List<InvoiceListDto>> GetInvoicesForTodayAsync();
    }
}
