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
        DbSet<Person> Person {  get; set; }
        DbSet<User> User { get; set; }
        DbSet<Rol> Rol { get; set; }
        DbSet<Form> Form { get; set; }
        DbSet<Permission> Permission { get; set; }
        DbSet<Module> Module { get; set; }
        DbSet<FormModule> FormModule {  get; set; }
        DbSet<RolFormPermission> RolFormPermission { get; set; }

        /// ==================================
        /// Parameter
        /// ==================================
        DbSet<Types> Type { get; set; }
        DbSet<Size> Size { get; set; }
        DbSet<Shape> Shape { get; set; }
        DbSet<Image> Image { get; set; }
        DbSet<Filled> Filled { get; set; }

        /// ==================================
        /// Parameter
        /// ==================================
        DbSet<Client> Client { get; set; }
        DbSet<Invoice> Invoice { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<InvoiceItem> InvoiceItem { get; set; }
        DbSet<Payment> Payment { get; set; }
    }
}
