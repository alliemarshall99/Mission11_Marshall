using Microsoft.EntityFrameworkCore;
using Mission11_Marshall.Models;

namespace Mission11_Marshall.Data
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignore the SQLiteSequence entity
            modelBuilder.Ignore<SQLiteSequence>();
        }
    }
}
