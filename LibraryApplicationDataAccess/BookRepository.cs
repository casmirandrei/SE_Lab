using LibraryApplicationDataAccess.Abstractions;
using LibraryApplicationDataAccess.Model;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.Security.Cryptography.X509Certificates;

namespace LibraryApplicationDataAccess
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}