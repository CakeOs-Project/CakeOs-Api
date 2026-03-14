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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Decimales
            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.OutstandingBalance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.SubTotal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            // Cascadas
            modelBuilder.Entity<Invoice>()
                .HasOne(e => e.Client)
                .WithMany(c => c.Invoices)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Invoice>()
                .HasOne(e => e.User)
                .WithMany(u => u.Invoices)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

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
