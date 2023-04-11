using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApplicationDataAccess.Model;
namespace LibraryApplicationDataAccess.Abstractions
{
    public interface IBookRepository : IBaseRepository<Book>
    {
    }
}
