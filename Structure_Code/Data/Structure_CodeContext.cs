using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Structure_Code.Models;

namespace Structure_Code.Data
{
    public class Structure_CodeContext : DbContext
    {
        public Structure_CodeContext (DbContextOptions<Structure_CodeContext> options)
            : base(options)
        {
        }

        public DbSet<Structure_Code.Models.Book> Book { get; set; } = default!;

        public DbSet<Structure_Code.Models.Author> Author { get; set; } = default!;
    }
}
