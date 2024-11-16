using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Models.Entities;

namespace VirtualLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
