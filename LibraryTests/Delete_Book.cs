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
    public class Delete_Book
    {
        [Fact]
        public async Task DeleteConfirmed_WithValidId_RemovesBookAndRedirectsToIndex()
        {
            // Arrange
            var bookId = 1; // Existing book ID
            var book = new Book { Id = bookId };
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(c => c.Books.FindAsync(bookId))
                .ReturnsAsync(book);
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.DeleteConfirmed(bookId);

            // Assert
            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockContext.Verify(c => c.Books.Remove(book), Times.Once);
        
        }

    }
}
