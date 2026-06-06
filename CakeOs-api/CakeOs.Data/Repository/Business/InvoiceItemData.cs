using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Enum.Invoice;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.InvoiceItem;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData
{
    public class InvoiceItemData : DataBase<InvoiceItem>, IInvoiceItemRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemData(ApplicationDbContext context) :
            base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task<InvoiceItem?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Set<InvoiceItem>()
                .Include(p => p.Product)
                .Include(f => f.Filled)
                .FirstOrDefaultAsync(i => i.Id == id, ct);
        }

        public async Task<bool> MarkAsReadyAsync(int itemId)
        {
            var item = await _context.Set<InvoiceItem>()
                .FirstOrDefaultAsync(i => i.Id == itemId);
            if (item == null) return false;

            item.Status = InvoiceItemStatus.Listo;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AllItemReady(int invoiceId)
        {
            return await _context.Set<InvoiceItem>()
                .Where(i => i.InvoiceId == invoiceId)
                .AllAsync(i => i.Status == InvoiceItemStatus.Listo);
        }
    }
}
