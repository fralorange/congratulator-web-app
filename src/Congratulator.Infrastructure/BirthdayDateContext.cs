using Congratulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Congratulator.Infrastructure
{
    public class BirthdayDateContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<BirthdayDate> Birthdays => Set<BirthdayDate>();
        public DbSet<Image> Images => Set<Image>();

        public BirthdayDateContext(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("Default")!;
        public BirthdayDateContext(string connectionString) => _connectionString = connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);
    }
}
