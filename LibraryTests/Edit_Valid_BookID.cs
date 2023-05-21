using Moq;
using Structure_Code.Controllers;
using Structure_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryTests
{
    public class Edit_Valid_BookID
    {
        [Fact]
        public async Task Edit_WithValidId_ReturnsViewResultWithBook()
        {
            // Arrange
            var bookId = 1; // Existing book ID
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(c => c.Books.FindAsync(bookId))
                .ReturnsAsync(new Book { Id = bookId, Title = "Book Title", Author = "Book Author" });
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.Edit(bookId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Book>(viewResult.Model);
            Assert.Equal(bookId, model.Id);
        }

    }
}
