using LibraryApplicationDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplicationDataAccess.Abstractions
{
   public interface IBaseRepository<T>
    {
        void Add(T item);
        void Add(Book item);
    }
}
