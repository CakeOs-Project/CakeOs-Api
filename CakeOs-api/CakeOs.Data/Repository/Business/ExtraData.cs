using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Repository.BusinessData;

public class ExtraData : DataBase<Extra>, IExtraRepository
{
    private readonly ApplicationDbContext _context;

    public ExtraData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
