using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Models;

namespace Online_Book_Store.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
