using CakeOs.Entity.Domain.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.Domain.security;

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

        // ===========================
        // Security
        // ===========================
        public ICollection<Person> Persons { get; set; } = new List<Person>();
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Rol> Roles { get; set; } = new List<Rol>();
        public ICollection<RolFormPermission> RolFormPermissions { get; set; } = new List<RolFormPermission>();

        // ===========================
        // Business
        // ===========================
        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

        // ===========================
        // Parameter
        // ===========================
        public ICollection<Filled> Filleds { get; set; } = new List<Filled>();
        public ICollection<Shape> Shapes { get; set; } = new List<Shape>();
        public ICollection<Size> Sizes { get; set; } = new List<Size>();
        public ICollection<Types> Types { get; set; } = new List<Types>();
    }
}
