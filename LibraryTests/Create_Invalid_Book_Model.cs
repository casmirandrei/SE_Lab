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
    public class Create_Invalid_Book_Model
    {
        [Fact]
        public async Task Create_WithInvalidBook_ReturnsViewResultWithBook()
        {
            // Arrange
            var book = new Book(); // Invalid book model
            var mockContext = new Mock<LibraryContext>();
            var controller = new BooksController(mockContext.Object);
            controller.ModelState.AddModelError("Title", "Title is required.");

            // Act
            var result = await controller.Create(book);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Book>(viewResult.Model);
            Assert.Equal(book, model);
        }

    }
}
