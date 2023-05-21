using Microsoft.EntityFrameworkCore;
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
    public class Delete_ValidID
    {
        [Fact]
        public async Task Delete_WithValidId_ReturnsViewResultWithBook()
        {
            // Arrange
            var bookId = 1; // Existing book ID
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(c => c.Books.FirstOrDefaultAsync(m => m.Id == bookId))
                .ReturnsAsync(new Book { Id = bookId, Title = "Book Title", Author = "Book Author" });
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.Delete(bookId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Book>(viewResult.Model);
            Assert.Equal(bookId, model.Id);
        }

    }
}
