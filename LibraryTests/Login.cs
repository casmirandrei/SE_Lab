using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Structure_Code.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests
{
    public class Login
    {
        [Fact]
        public async Task Login_ChallengeAsyncWithGoogleDefaultsAuthenticationScheme()
        {
            // Arrange
            var logger = Mock.Of<ILogger<HomeController>>();
            var controller = new HomeController(logger);
            var authenticationScheme = GoogleDefaults.AuthenticationScheme;
            var redirectUri = controller.Url.Action("Index");

            // Act
            await controller.Login();

            // Assert
            Assert.NotNull(controller.HttpContext);
            Assert.NotNull(controller.HttpContext.AuthenticateAsync(authenticationScheme));
          
        }

    }
}
