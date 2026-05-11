using Microsoft.EntityFrameworkCore;
using MultiTenantSolution.Domain;
using MultiTenantSolution.Provider;

namespace MultiTenantSolution.Data
{
    public class AppDbContext : DbContext
    {
        private TenantData _tenantData;
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(TenantData tenantData, DbContextOptions<AppDbContext> options) : base(options)
        {
            _tenantData = tenantData;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Alice Santos", tenantId = "tenant-1" },
                new Person { Id = 2, Name = "Bob Silva", tenantId = "tenant-1" },
                new Person { Id = 3, Name = "Carlos Oliveira", tenantId = "tenant-2" },
                new Person { Id = 4, Name = "José Carvalho", tenantId = "tenant-2" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Dell XPS 15", Description = "High-performance laptop", tenantId = "tenant-1" },
                new Product { Id = 2, Name = "Mouse Logitech MX Master", Description = "Ergonomic wireless mouse", tenantId = "tenant-1" },
                new Product { Id = 3, Name = "Camiseta Polo Premium", Description = "Premium quality polo shirt", tenantId = "tenant-2" },
                new Product { Id = 4, Name = "Tênis Esportivo Nike", Description = "Comfortable sports shoes", tenantId = "tenant-2" }
            );

            //Filtro global para garantir que apenas os dados do tenant atual sejam acessados
            modelBuilder.Entity<Person>().HasQueryFilter(p => p.tenantId == _tenantData.TenantId);
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.tenantId == _tenantData.TenantId);
        }

    }
}
