using CakeOs.Entity.Domain.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.Domain.Security;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.Domain.security;
using CakeOS.Utilities.Provider;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Entity.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ITenantProvider? _tenantProvider;
        private int? TenantId => _tenantProvider?.TenantId;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ITenantProvider? tenantProvider = null)
            : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===========================
            // Filtros TenantId + IsDeleted
            // ===========================
            modelBuilder.Entity<Person>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<User>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Rol>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<RolFormPermission>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Client>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Invoice>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Payment>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Types>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Size>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Shape>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Filled>()
                .HasQueryFilter(e =>
                    (TenantId == null || e.TenantId == TenantId) && e.IsActive && !e.IsDeleted);

            // ===========================
            // Filtros solo IsDeleted
            // ===========================
            modelBuilder.Entity<Tenant>()
                .HasQueryFilter(e => !e.IsDeleted);

            // ===========================
            // Seed: tenant de desarrollo
            // ===========================
            modelBuilder.Entity<Tenant>().HasData(new Tenant
            {
                Id = 1,
                Name = "CakeOs Dev",
                Slug = "cakeos",
                Phone = "0000000000",
                Address = "Dirección de prueba",
                IsActive = true,
                IsDeleted = false
            });

            modelBuilder.Entity<Form>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<Module>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<Permission>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<FormModule>()
                .HasQueryFilter(e => !e.IsDeleted);

            // ===========================
            // Decimales
            // ===========================
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

            // ===========================
            // Cascadas
            // ===========================
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
                .WithMany(u => u.Payments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Tenant → todas las entidades tenant: sin cascade delete
            modelBuilder.Entity<Person>()
                .HasOne(e => e.Tenant).WithMany(t => t.Persons)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Tenant).WithMany(t => t.Users)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rol>()
                .HasOne(e => e.Tenant).WithMany(t => t.Roles)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolFormPermission>()
                .HasOne(e => e.Tenant).WithMany(t => t.RolFormPermissions)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(e => e.Tenant).WithMany(t => t.Clients)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(e => e.Tenant).WithMany(t => t.Invoices)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(e => e.Tenant).WithMany(t => t.Payments)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Tenant).WithMany(t => t.Products)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Filled>()
                .HasOne(e => e.Tenant).WithMany(t => t.Filleds)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shape>()
                .HasOne(e => e.Tenant).WithMany(t => t.Shapes)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Size>()
                .HasOne(e => e.Tenant).WithMany(t => t.Sizes)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Types>()
                .HasOne(e => e.Tenant).WithMany(t => t.Types)
                .HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        }

        // ===========================
        // Security
        // ===========================
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<FormModule> FormModule { get; set; }
        public DbSet<RolFormPermission> RolFormPermission { get; set; }

        // ===========================
        // Parameter
        // ===========================
        public DbSet<Types> Type { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Shape> Shape { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Filled> Filled { get; set; }

        // ===========================
        // Business
        // ===========================
        public DbSet<Client> Client { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}