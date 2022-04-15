using Microsoft.EntityFrameworkCore;

namespace BookStoreApp
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString =
                @"Server=(localdb)\mssqllocaldb;
             Database=BookStoreAppDb;
             Trusted_Connection=True";

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}