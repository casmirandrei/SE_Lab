using ikvm.runtime;
using Microsoft.AspNetCore.Mvc.Testing;
using NuGet.Protocol;
using Structure_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests
{
    public class UnitTest3
    {
        private WebApplicationFactory<Book> _factory;

        public UnitTest3(WebApplicationFactory<Book> factory) => _factory = factory;
        [Fact]
        public async Task SearchBooksByTitle()
        {
            //Arrange
            var client = _factory.CreateClient();
            var searchString = "Title";
            var expectedTitle = "Demonii";

            //Act
            var response = await client.GetAsync($"/Books?SearchString={searchString}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var model = responseString.FromJson<List<Book>>();

            //Assert
            Assert.True(model.Count > 0, "The search result should not be empty.");
            Assert.True(model.All(b => b.Title.Contains(searchString)), $"The search result should contain '{searchString}' in the title.");
            Assert.True(model.Any(b => b.Title == expectedTitle), $"The search result should contain a book with the title '{expectedTitle}'.");
        }
    }
}
