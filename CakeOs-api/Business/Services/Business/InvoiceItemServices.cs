using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.DTOs.Transversal;
using CakeOs.Entity.Enum.Invoice;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.InvoiceItem;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Services.Business
{
    public class InvoiceItemServices : ServicesBase<InvoiceItemDetailDto, InvoiceItemCreateDto, InvoiceItem>, IInvoiceItemServices
    {
        private readonly IInvoiceItemRepository _item;
        private readonly IInvoiceRepository _invoice;
        private readonly IMapper _mapper;

        public InvoiceItemServices(IInvoiceItemRepository item, IInvoiceRepository invoice, IMapper mapper, ILoggerFactory loggerFactory)
            : base(item, mapper, loggerFactory)
        {
            _item = item;
            _invoice = invoice;
            _mapper = mapper;
        }

        public async Task<ResponseDto> MarkAsReadyAsync(int itemId)
        {
            if (itemId <= 0) throw new ArgumentOutOfRangeException("El id debe ser mayor a 0.");

            var item = await _item.GetByIdAsync(itemId);

            if (item is null) throw new Exception("El ítem no existe.");

            if (item.Status == InvoiceItemStatus.Listo)
                return ResponseDto.Fail("El ítem ya está marcado como listo.");

            item.Status = InvoiceItemStatus.Listo;
            await _item.SaveChangesAsync();

            var allReady = await _item.AllItemReady(item.InvoiceId);

            if (allReady)
            {
                var invoice = await _invoice.GetByIdAsync(item.InvoiceId);

                if (invoice is not null)
                {
                    invoice.Status = InvoiceStatus.Lista;
                    await _invoice.SaveChangesAsync();
                }
            }

            return ResponseDto.Ok("Ítem marcado como listo.");
        }
    }
}
