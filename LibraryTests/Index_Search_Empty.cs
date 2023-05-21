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
    public class Index_Search_Empty
    {
        [Fact]
        public async Task Index_ReturnsViewResultWithListOfBooks()
        {
            // Arrange
            var mockContext = new Mock<LibraryContext>();
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = await controller.Index("");

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(viewResult.Model);
            Assert.Equal(3, model.Count()); // Adjust the expected count based on your data
        }


    }
}
