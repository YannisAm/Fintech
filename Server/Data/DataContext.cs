using Fintech.Shared.Models;

namespace Fintech.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Security> Securities { get; set; }
        public DbSet<Portfolio> Portofolios { get; set; }
    }
}
