using HotelApi.Application.Services.Hotels.Sorting;
using HotelApi.Domain.Business.Calculus;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Location.Params;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.UnitTests.Application
{
    public class SortTest
    {
        private SortHotelsByDistance sortHotelsByDistance;
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            sortHotelsByDistance = new SortHotelsByDistance();
            calculator = new Calculator();
        }

        [Test]
        public void SortTest_ReturnsSortedElements()
        {

            //Preparation
            HotelDto[] hotels = new HotelDto[]
             {
                new HotelDto
                {
                    Id = 1,
                    Name = "Hotel Aurora",
                    Price = 120.50m,
                    Location = new LocationDto
                    {
                        Id = 101,
                        Latitude = 45.815399,
                        Longitude = 15.966568,
                        Hotels = null
                    }
                },
                new HotelDto
                {
                    Id = 2,
                    Name = "Grand Palace",
                    Price = 220.00m,
                    Location = new LocationDto
                    {
                        Id = 102,
                        Latitude = 45.812345,
                        Longitude = 15.980123,
                        Hotels = null
                    }
                },
                new HotelDto
                {
                    Id = 3,
                    Name = "City Comfort Inn",
                    Price = 89.99m,
                    Location = new LocationDto
                    {
                        Id = 103,
                        Latitude = 45.820001,
                        Longitude = 15.950001,
                        Hotels = null
                    }
                },
                new HotelDto
                {
                    Id = 4,
                    Name = "Panorama View Hotel",
                    Price = 310.00m,
                    Location = new LocationDto
                    {
                        Id = 104,
                        Latitude = 45.830500,
                        Longitude = 15.940300,
                        Hotels = null
                    }
                },
                new HotelDto
                {
                    Id = 5,
                    Name = "Budget Stay",
                    Price = 55.00m,
                    Location = new LocationDto
                    {
                        Id = 105,
                        Latitude = 45.800200,
                        Longitude = 15.970900,
                        Hotels = null
                    }
                }
             };

            LocationQuery userLocation = new LocationQuery
            {
                Latitude = 45.817200,
                Longitude = 15.967800
            };

            sortHotelsByDistance.SetParams(hotels, userLocation);



            //Execution
            HotelDto[]? results = sortHotelsByDistance.Execute();


            //Assertion
            for (int i = 0; i < results.Length - 1; i++)
            {
                Assert.LessOrEqual(calculator.CalculateDistance(userLocation, new LocationQuery(results[i].Location)),
                    calculator.CalculateDistance(userLocation, new LocationQuery(results[i + 1].Location)));
            }
        }

        [Test]
        public void SortTest_EmptyArray_ReturnsEmptyArray()
        {
            //Preparation
            HotelDto[] hotels = Array.Empty<HotelDto>();
            LocationQuery userLocation = new LocationQuery
            {
                Latitude = 45.817200,
                Longitude = 15.967800
            };
            sortHotelsByDistance.SetParams(hotels, userLocation);
            //Execution
            HotelDto[] results = sortHotelsByDistance.Execute();
            //Assertion
            Assert.IsNotNull(results);
            Assert.IsEmpty(results);
        }

        [Test]
        public void SortTest_SingleElementArray_ReturnsSameElement()
        {
            //Preparation
            HotelDto[] hotels = new HotelDto[]
            {
                new HotelDto
                {
                    Id = 1,
                    Name = "Hotel Aurora",
                    Price = 120.50m,
                    Location = new LocationDto
                    {
                        Id = 101,
                        Latitude = 45.815399,
                        Longitude = 15.966568,
                        Hotels = null
                    }
                }
            };

            LocationQuery userLocation = new LocationQuery
            {
                Latitude = 45.817200,
                Longitude = 15.967800
            };

            sortHotelsByDistance.SetParams(hotels, userLocation);

            //Execution
            HotelDto[] results = sortHotelsByDistance.Execute();

            //Assertion
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Length);
            Assert.AreEqual(hotels[0], results[0]);
        }
    }
}