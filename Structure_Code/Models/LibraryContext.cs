using Microsoft.EntityFrameworkCore;
using Structure_Code.Models;
using System.Security.Policy;

namespace Structure_Code.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    

    }
}


