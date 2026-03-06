using CakeOs.Data.Interfaz.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Data.Repository.Data
{
    internal class Data : IData<Data>
    {
        public Task<Data> AddAsync(Data entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Data>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Data?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Data> UpdateAsync(Data entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ActivateAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<(IEnumerable<Data> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? filter = null)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
