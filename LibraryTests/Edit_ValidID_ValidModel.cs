using Microsoft.AspNetCore.Mvc;
using Moq;
using Structure_Code.Controllers;
using Structure_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests
{
    public class Edit_ValidID_ValidModel
    {
        [Fact]
        public async Task Edit_WithValidIdAndValidBook_RedirectsToIndex()
        {
            // Arrange
            var bookId = 1; // Existing book ID
            var book = new Book { Id = bookId, Title = "Updated Book Title", Author = "Updated Book Author" };
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(c => c.Update(book));
         
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.Edit(bookId, book);

            // Assert
            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    }
}
