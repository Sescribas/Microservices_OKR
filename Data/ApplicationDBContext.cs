using Microsoft.EntityFrameworkCore;
using Domain;
using OKR.Common.Persistence.Database.Configuration;

namespace Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfig(modelBuilder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new UserConfiguration(modelBuilder.Entity<User>());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}