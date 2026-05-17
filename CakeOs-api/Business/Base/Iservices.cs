using CakeOs.Entity.DTOs.Transversal;
using CakeOS.Entity.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Base
{
    public interface IServices<TDtoList, TDtoCreate, TEntity>
        where TDtoList : class
        where TDtoCreate : class
        where TEntity : BaseDomain
    {
        Task<IEnumerable<TDtoList>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TDtoList?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<TDtoList> CreateAsync(TDtoCreate dto);
        Task<ResponseDto> UpdateAsync(int id, TDtoCreate dto);
        Task<ResponseDto> ToggleActiveAsync(int id, bool isActive);
        Task<ResponseDto> SoftDeleteAsync(int id);
    }
}
