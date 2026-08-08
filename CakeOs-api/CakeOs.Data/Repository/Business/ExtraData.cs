using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

public class ExtraData : DataBase<Extra>, IExtraRepository, IDataName<Extra>
{
    private readonly ApplicationDbContext _context;

    public ExtraData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Extra?> GetByName(string name)
    {
        return await _context.Set<Extra>()
            .FirstOrDefaultAsync(x => x.Name == name);
    }
}
