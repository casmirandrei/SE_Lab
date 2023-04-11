using LibraryApplicationDataAccess.Abstractions;
using LibraryApplicationDataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplicationDataAccess
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
