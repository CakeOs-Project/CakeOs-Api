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
