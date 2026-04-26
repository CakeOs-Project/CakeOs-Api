using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Data.Repository.BusinessData
{
    public class InvoiceItemData : Data<InvoiceItem>, IInvoiceItemData
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemData(ApplicationDbContext context) : 
            base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
