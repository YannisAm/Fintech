using Fintech.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Security> Securities { get; set; }
    }
}
