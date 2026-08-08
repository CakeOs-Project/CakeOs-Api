using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Data.Base
{
    public interface IDataName<TEntiy> where TEntiy : class
    {
        Task<TEntiy> GetByName (string name);
    }
}
