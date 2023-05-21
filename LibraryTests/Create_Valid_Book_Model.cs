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
    public class Create_Valid_Book_Model
    {
        [Fact]
        public async Task Create_WithValidBook_RedirectsToIndex()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Book Title", Author = "Book Author" };
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(c => c.Add(book));
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.Create(book);

            // Assert
            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    }
}
