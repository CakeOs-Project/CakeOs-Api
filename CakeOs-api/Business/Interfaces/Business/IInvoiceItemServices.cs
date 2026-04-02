using CakeOs.Business.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.InvoiceItem;

namespace CakeOs.Business.Interfaces.Business
{
    public interface IInvoiceItemServices : IServices<InvoiceItemDetailDto,InvoiceItemCreateDto, Invoice>
    {
    }
}
