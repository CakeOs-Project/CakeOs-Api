using CakeOs.Data.Interfaz.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Data.Repository.Data
{
    internal class BaseData : IData <BaseData>
    {
        public Task<BaseData> CreateAsync(BaseData entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<BaseData>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<BaseData?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<BaseData> UpdateAsync(BaseData entity)
        {
            throw new NotImplementedException();
        }
}
