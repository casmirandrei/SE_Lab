using Microsoft.Extensions.Logging;
using Moq;
using Structure_Code.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryTests
{
    public class Privacy
    {
        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Arrange
            var logger = Mock.Of<ILogger<HomeController>>();
            var controller = new HomeController(logger);

            // Act
            var result = controller.Privacy();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

    }
}
