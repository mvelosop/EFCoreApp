using EFCore.App.Base;
using EFCore.App.Config;
using EFCore.App.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore.App.Data
{
    public class CommonDbContext : DbContext
    {
        // Must not be null or empty for initial create migration
        private string _connectionString = "ConnectionString";

        // Default constructor for initial create migration
        public CommonDbContext()
        {
        }

        // Normal use constructor
        public CommonDbContext(ConnectionStrings connectionStrings)
        {
            _connectionString = connectionStrings.DefaultConnection;
        }

        public DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new CurrencyConfiguration());
        }
    }
}
