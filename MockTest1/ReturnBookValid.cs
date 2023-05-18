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
    public void GetBookTitleById_ValidId_ReturnsTitle()
    {
        // Arrange
        int bookId = 1;
        string expectedTitle = "Sample Book Title";
        var mockRepository = new Mock<IBookRepository>();
        mockRepository.Setup(repo => repo.GetBookById(bookId)).Returns(new Book { Title = expectedTitle });
        LibraryService libraryService = new LibraryService(mockRepository.Object);

        // Act
        string actualTitle = libraryService.GetBookTitleById(bookId);

        // Assert
        Xunit.Assert.Equal(expectedTitle, actualTitle);
        mockRepository.Verify(repo => repo.GetBookById(bookId), Times.Once);
    }
}