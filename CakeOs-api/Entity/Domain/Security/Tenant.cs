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
        /// <summary>
        /// Campo que se usa en la url del frontend, que nos permitira diferenciar
        /// tanto visual y como internamente que estamos hablando de una 
        /// tenant especifica
        /// </summary>
        public string Slug { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
