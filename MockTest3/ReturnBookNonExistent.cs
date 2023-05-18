using Moq;
using Xunit;

public class Book
{
    public string Title { get; set; }
}

public interface IBookRepository
{
    Book GetBookById(int id);
}

public class LibraryService
{
    private readonly IBookRepository _bookRepository;

    public LibraryService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public string GetBookTitleById(int id)
    {
        Book book = _bookRepository.GetBookById(id);
        return book?.Title;
    }
}

public class LibraryServiceTests
{
    [Fact]
    public void GetBookTitleById_BookNotFound_ReturnsNull()
    {
        // Arrange
        int nonExistingBookId = 10;
        var mockRepository = new Mock<IBookRepository>();
        mockRepository.Setup(repo => repo.GetBookById(nonExistingBookId)).Returns((Book)null);
        LibraryService libraryService = new LibraryService(mockRepository.Object);

        // Act
        string actualTitle = libraryService.GetBookTitleById(nonExistingBookId);

        // Assert
        Xunit.Assert.Null(actualTitle);
        mockRepository.Verify(repo => repo.GetBookById(nonExistingBookId), Times.Once);
    }
}