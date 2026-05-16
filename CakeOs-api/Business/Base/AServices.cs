using CakeOS.Entity.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Base
{
    public abstract class AServices<TDtoList, TDtoCreate, TEntity> : IServices<TDtoList, TDtoCreate, TEntity>
        where TDtoList : class
        where TDtoCreate : class
        where TEntity : BaseDomain
    {
        public abstract Task<IEnumerable<TDtoList>> GetAllAsync( CancellationToken cancellationToken = default);
        public abstract Task<TDtoList?> GetByIdAsync(int id, CancellationToken ct = default);
        public abstract Task<TDtoList> CreateAsync(TDtoCreate dto);
        public abstract Task<TDtoList> UpdateAsync(int id, TDtoCreate dto);
        public abstract Task<bool> ToggleActiveAsync(int id, bool isActive);
        public abstract Task<bool> SoftDeleteAsync(int id);
    }
}
