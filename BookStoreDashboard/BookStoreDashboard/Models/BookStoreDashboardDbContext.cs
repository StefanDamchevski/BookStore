using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreDashboard.Models
{
    public class BookStoreDashboardDbContext : IdentityDbContext
    {
        public BookStoreDashboardDbContext(DbContextOptions<BookStoreDashboardDbContext> options) : base(options){}

    }
}
