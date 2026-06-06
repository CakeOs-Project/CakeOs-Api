using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.Business;

namespace CakeOS.Entity.Domain.security
{
    public class Person : BaseTenantDomain
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TypeDocument { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public DateTime CreateAt { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}