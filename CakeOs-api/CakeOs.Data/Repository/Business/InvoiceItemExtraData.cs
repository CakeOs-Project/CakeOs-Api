using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Business;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

public class InvoiceItemExtraData : DataBase<InvoiceItemExtra>, IInvoiceItemExtraRepository
{
    private readonly ApplicationDbContext _context;

    public InvoiceItemExtraData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public override async Task<InvoiceItemExtra?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<InvoiceItemExtra>()
            .Include(x => x.Extra)
            .Include(x => x.InvoiceItem)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
