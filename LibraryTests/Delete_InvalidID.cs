using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class Delete_InvalidID
    {
        [Fact]
        public async Task Delete_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var bookId = 10; // Non-existing book ID
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(expression: c => c.Books.FirstOrDefaultAsync(m => m.Id == bookId))
                .ReturnsAsync((Book)null);
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.Delete(bookId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

    }
}
