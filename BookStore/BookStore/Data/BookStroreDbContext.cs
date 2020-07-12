using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStroreDbContext : DbContext
    {
        public BookStroreDbContext(DbContextOptions<BookStroreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BookOrders> BookOrders { get; set; }
    }
}
