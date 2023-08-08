using Microsoft.EntityFrameworkCore;
using OKR.Common.Domain;
using OKR.Common.Persistence.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Persistence.Database.ProductDbContext
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfig(modelBuilder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new UserConfiguration(modelBuilder.Entity<User>());
            _ = new ProductConfiguration(modelBuilder.Entity<Product>());
            _ = new CategoryConfiguration(modelBuilder.Entity<Category>());

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

}
