using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplicationDataAccess.Model
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       public IEnumerable<Book>? BooksInSale { get; set;}
    }
}
