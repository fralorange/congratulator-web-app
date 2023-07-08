using Congratulator.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Congratulator.Infrastructure
{
    public class BirthdayDateContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<BirthdayDate> Birthdays => Set<BirthdayDate>();
        public BirthdayDateContext(string connectionString) => _connectionString = connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);
    }
}
