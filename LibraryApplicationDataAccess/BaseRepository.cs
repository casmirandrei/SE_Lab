using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApplicationDataAccess.Abstractions;
using LibraryApplicationDataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplicationDataAccess
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        private DbContext dbContext;
        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    

        public void Add(T item)
        {
            dbContext.Set<T>().Add(item);
            dbContext.SaveChanges();
        }

        public void Add(Book item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>()
                 .ToList();
        }
    }
}
