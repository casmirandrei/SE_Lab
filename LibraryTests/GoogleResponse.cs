using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Moq;
using Structure_Code.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryTests
{
    public class GoogleResponse
    {
        private object claimJson;

        [Fact]
        public async Task GoogleResponse_ReturnsJsonResultWithClaims()
        {
            // Arrange
            var logger = Mock.Of<ILogger<HomeController>>();
            var controller = new HomeController(logger);
            var authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, "1"),
        new Claim(ClaimTypes.Name, "John Doe"),
        // Add more claims as needed
    };
            var identity = new ClaimsIdentity(claims, authenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var result = AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, authenticationScheme));
            controller.HttpContext.User = claimsPrincipal;

            // Act
            var actionResult = await controller.GoogleResponse();
            var jsonResult = Assert.IsType<JsonResult>(actionResult);

            // Assert
            Assert.NotNull(jsonResult);
            var claimsJson = Assert.IsType<IEnumerable<object>>(jsonResult.Value);
            Assert.Equal(claims.Length, claimsJson.Count());
            foreach (var claim in claims)
            {

                Assert.Equal(claim.Type, claimJson.GetType().GetProperty("Type").GetValue());

            }
        }
    }
}
