using Microsoft.EntityFrameworkCore;
using Pagination.Models;

namespace Pagination.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly string connectionString;

        public ApplicationContext(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
