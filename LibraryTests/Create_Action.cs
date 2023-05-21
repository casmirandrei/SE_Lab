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
    public class Create_Action
    {
        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange
            var mockContext = new Mock<LibraryContext>();
            var controller = new BooksController(mockContext.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.Model);
        }

    }
}
