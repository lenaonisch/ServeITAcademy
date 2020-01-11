using System;
using System.Linq;
using Xunit;
using Moq;
using TravelAgencyHelper.Models;
using TravelAgencyHelper.Data;

namespace XUnitTravelAgencyHelperTest
{
    public class RoutesTest
    {
        [Fact]
        public void FullRoute()
        {
            Mock<IRoutesRepository> mock = new Mock<IRoutesRepository>();
            mock.Setup(m => m.Get()).Returns(SeedData.routes.AsQueryable<Route>);


        }
    }
}
