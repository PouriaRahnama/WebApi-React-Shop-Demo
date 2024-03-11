using Microsoft.EntityFrameworkCore;
using Service.Catalog.API.Infrustructure.MapConfig;
using Service.Catalog.API.Models;

namespace Service.Catalog.API.Infrustructure.Persistence
{
    public class SqlServerApplicationDB:DbContext
    {
        public SqlServerApplicationDB(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfig).Assembly);
        }

        public DbSet<Product> Product {get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
    }
}