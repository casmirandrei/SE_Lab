using LibraryApplicationDataAccess.Abstractions;
using LibraryApplicationDataAccess.Model;

namespace LibraryApplicationLogic
{
    public class BookService
    {   
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository) 
        {
            this.bookRepository = bookRepository;
        }
        void AddBookToLibrary(Book book)
        {
            bookRepository.Add(book);
        }
    }
}