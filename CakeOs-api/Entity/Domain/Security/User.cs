using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Business;

namespace CakeOS.Entity.Domain.security
{
    public class User : BaseAuditory
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public int RolId { get; set; }

        public Person? Person { get; set; }
        public Rol? Rol { get; set; }
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
