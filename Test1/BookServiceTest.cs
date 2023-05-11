using LibraryApplicationDataAccess.Abstractions;
using LibraryApplicationDataAccess.Model;

namespace Test1
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