using CakeOS.Entity.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.Domain.Security
{
    public class Tenant : BaseDomain
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!; // panaderia-el-buen-sabor
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
