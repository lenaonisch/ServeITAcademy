//using System;
//using System.Linq;
//using Xunit;
//using Moq;
//using TravelAgencyHelper.Models;
//using TravelAgencyHelper.Data;

//namespace XUnitTravelAgencyHelperTest
//{
//    public class RoutesTest
//    {
//        [Fact]
//        public void FullRoute()
//        {
//            Mock<IRoutesRepository> mock = new Mock<IRoutesRepository>();
//            mock.Setup(m => m.Get()).Returns(SeedData.routes.AsQueryable<Route>);


//        }
//    }
//}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TravelAgencyHelper.Models;
using TravelAgencyHelper.Data;
using Xunit;
using System.Net.Http;

namespace XUnitTravelAgencyHelperTest
{
    #region snippet1
    public class BasicTests
        : IClassFixture<WebApplicationFactory<TravelAgencyHelper.Startup>>
    {
        private const string GET_URL = "api/Route/Get/";
        private const string DEL_URL = "api/Route/Delete/";
        private const string SEARCH_URL = "api/Route/Search/";
        private const string UPDATE_URL = "api/Route/Put/";
        private const string ADD_URL = "api/Route/Post";

        private readonly WebApplicationFactory<TravelAgencyHelper.Startup> _factory;

        public BasicTests(WebApplicationFactory<TravelAgencyHelper.Startup> factory)
        {
            _factory = factory;
        }

        private async Task<Route> SearchRoute(HttpClient client, int seedIndex)
        {
            var getIdResponse = await client.GetAsync(SEARCH_URL + SeedData.routes[seedIndex].Name);
            var routes = await getIdResponse.Content.ReadAsAsync<List<Route>>();
            if (routes.Count > 0)
            {
                return routes[0];
            }

            return null;
        }

        [Theory]
        [InlineData(UPDATE_URL, 4)]
        public async Task Update(string url, int seedIndex)
        {
            var client = _factory.CreateClient();

            Route route = await SearchRoute(client, seedIndex);
            route.Price = 100500;
            var response = await client.PutAsync<Route>(url + route.Id, route, new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            
            
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var updatedResponse = await client.GetAsync(GET_URL+route.Id);
            Route updatedRoute = await updatedResponse.Content.ReadAsAsync<Route>();
            
            Assert.Equal(route.Price, updatedRoute.Price);
        }

        [Theory]
        //[InlineData("api/Route/Search/Name=Сванетия" )]
        [InlineData("Сванетия")]
        public async Task Search(string search)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(SEARCH_URL + search);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            //Assert.Equal("application/json; charset=utf-8",
            //    response.Content.Headers.ContentType.ToString());
            var result = await response.Content.ReadAsAsync<List<Route>>();
            Assert.True(result.Count > 0);
            Assert.All(result, route => route.Name.Contains(search));
        }

        [Theory]
        //[InlineData("api/Route/Search/Name=Сванетия" )]
        [InlineData(5)]
        public async Task Delete(int seedIndex)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var getIdResponse = await client.GetAsync(SEARCH_URL + SeedData.routes[seedIndex].Name);
            var route = await getIdResponse.Content.ReadAsAsync<List<Route>>();
            var routeId = route[0].Id;
            var delResponse = await client.DeleteAsync(DEL_URL + routeId);
            var getResponse = await client.GetAsync(GET_URL + routeId);
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);            
        }

        [Fact]
        //[InlineData("api/Route/Search/Name=Сванетия" )]
       // [InlineData(5)]
        public async Task Add()
        {

            var client = _factory.CreateClient();

            Route route = new Route() { Category = "Восхождение", Name = "ТЕСТ", Price = 100500 };
            await client.PostAsJsonAsync<Route>(ADD_URL, route);

            var response = await client.GetAsync(SEARCH_URL + route.Name);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            //Assert.Equal("application/json; charset=utf-8",
            //    response.Content.Headers.ContentType.ToString());
            var result = await response.Content.ReadAsAsync<List<Route>>();
            
            Assert.True(result.Count > 0);
            Assert.Equal(result[0].Name, route.Name);
            Assert.Equal(result[0].Category, route.Category);

            await client.DeleteAsync(DEL_URL + result[0].Id);
        }
    }
    #endregion
}