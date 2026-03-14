using CakeOs.Entity.Domain.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOS.Entity.Domain.CakeEntity;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Entity.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        /// ==================================
        /// Security
        /// ==================================
        public DbSet<Person> Person {  get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<FormModule> FormModule {  get; set; }
        public DbSet<RolFormPermission> RolFormPermission { get; set; }

        /// ==================================
        /// Parameter
        /// ==================================
        public DbSet<CakeOs.Entity.Domain.Parameter.Type> Type { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Shape> Shape { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Filled> Filled { get; set; }

        /// ==================================
        /// Billing / Business
        /// ==================================
        public DbSet<Client> Client { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
