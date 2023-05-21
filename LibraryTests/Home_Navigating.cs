using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests
{
    public class Home_Navigating 
    {
        private readonly HttpClient _client;

      
        [Fact]
        public async Task HomePage_Navbar_BooksLink_ShouldNavigateToBooksPage()
        {
            // Arrange
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Act
            var booksLink = response
                .RequestMessage
                .GetUri().GetLeftPart(UriPartial.Authority) + "/Books";
            var booksResponse = await _client.GetAsync(booksLink);

            // Assert
            booksResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, booksResponse.StatusCode);
        }
    }
}
