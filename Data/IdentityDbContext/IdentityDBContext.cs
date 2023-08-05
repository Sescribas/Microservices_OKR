using Microsoft.EntityFrameworkCore;
using OKR.Common.Domain;
using OKR.Common.Persistence.Database.Configuration;

namespace OKR.Common.Persistence.Database.IdentityDbContext
{
    public class IdentityDBContext : DbContext
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options) { }

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