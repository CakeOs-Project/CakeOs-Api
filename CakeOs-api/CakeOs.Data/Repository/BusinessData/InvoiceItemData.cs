using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.Business;

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
    }
}
