using Microsoft.EntityFrameworkCore;
using TestEFCoreMySQL.Models;

namespace TestEFCoreMySQL.Contexts
{
    public class DbAppContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }

        public DbAppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;user=root;password=;database=testefcoremysql_db;",
                new MySqlServerVersion(new Version(8, 2, 12)
            ));
        }

    }
}
