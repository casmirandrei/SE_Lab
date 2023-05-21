using Microsoft.Extensions.Logging;
using Moq;
using Structure_Code.Controllers;
using System.Web.Mvc;

namespace LibraryTests
{
    public class Home_Index
    {

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var logger = Mock.Of<ILogger<HomeController>>();
            var controller = new HomeController(logger);

            // Act
            var result = controller.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

    }
}