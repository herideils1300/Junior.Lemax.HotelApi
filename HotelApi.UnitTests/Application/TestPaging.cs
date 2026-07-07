using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Application.Services.Hotels.Pagination;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Users.Dto;
using NUnit.Framework.Constraints;

namespace HotelApi.UnitTests.Application
{
    public class TestPaging
    {
        PaginateHotels _paginate;

        [SetUp]
        public void Setup()
        {
            _paginate = new PaginateHotels();
        }

        [Test]
        public void TestPaging_ReturnsOnePage()
        {
            var fifteenHotels = SampleData.Samples.GetHotels();
            var query = new HotelQuery()
            {
                HighBudget = 0,
                LowBudget = 0,
                Page = 1,
                RadiusInMiles = 0,
                UserLocation = new Domain.Data.Location.Params.LocationQuery
                {
                    Latitude = 43,
                    Longitude = 15
                }
            };

            _paginate.SetParams(fifteenHotels, query);


            var result = _paginate.Execute();

            Assert.That(result.Length == 10);

        }
    }
}
