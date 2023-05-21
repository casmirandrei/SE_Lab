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
    public class Edit_Invalid_BookID
    {
        [Fact]
        public async Task Edit_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var bookId = 10; // Non-existing book ID
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(c => c.Books.FindAsync(bookId))
                .ReturnsAsync((Book)null);
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.Edit(bookId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

    }
}
