using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.UnitTests.SampleData
{
    internal static class Samples
    {



        public static HotelDto[] GetHotels()
        {
            return new HotelDto[]
                {
                    new HotelDto
                    {
                        Id = 1,
                        Name = "Hotel Aurora",
                        Price = 120.50m,
                        Location = new LocationDto { Id = 101, Latitude = 45.8151, Longitude = 15.9668, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 2,
                        Name = "Grand Palace",
                        Price = 220.00m,
                        Location = new LocationDto { Id = 102, Latitude = 45.8123, Longitude = 15.9801, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 3,
                        Name = "City Comfort Inn",
                        Price = 89.99m,
                        Location = new LocationDto { Id = 103, Latitude = 45.8200, Longitude = 15.9500, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 4,
                        Name = "Panorama View Hotel",
                        Price = 310.00m,
                        Location = new LocationDto { Id = 104, Latitude = 45.8305, Longitude = 15.9403, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 5,
                        Name = "Budget Stay",
                        Price = 55.00m,
                        Location = new LocationDto { Id = 105, Latitude = 45.8002, Longitude = 15.9709, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 6,
                        Name = "Zagreb Central Hotel",
                        Price = 150.00m,
                        Location = new LocationDto { Id = 106, Latitude = 45.8130, Longitude = 15.9770, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 7,
                        Name = "Blue Lagoon Suites",
                        Price = 180.75m,
                        Location = new LocationDto { Id = 107, Latitude = 45.8182, Longitude = 15.9621, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 8,
                        Name = "Royal Heritage Hotel",
                        Price = 260.00m,
                        Location = new LocationDto { Id = 108, Latitude = 45.8167, Longitude = 15.9699, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 9,
                        Name = "Garden View Inn",
                        Price = 95.00m,
                        Location = new LocationDto { Id = 109, Latitude = 45.8195, Longitude = 15.9555, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 10,
                        Name = "Luxury Plaza",
                        Price = 340.00m,
                        Location = new LocationDto { Id = 110, Latitude = 45.8222, Longitude = 15.9477, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 11,
                        Name = "Old Town Residence",
                        Price = 130.00m,
                        Location = new LocationDto { Id = 111, Latitude = 45.8129, Longitude = 15.9644, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 12,
                        Name = "Riverside Hotel",
                        Price = 175.00m,
                        Location = new LocationDto { Id = 112, Latitude = 45.8144, Longitude = 15.9712, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 13,
                        Name = "Parkside Lodge",
                        Price = 110.00m,
                        Location = new LocationDto { Id = 113, Latitude = 45.8179, Longitude = 15.9588, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 14,
                        Name = "Skyline Tower Hotel",
                        Price = 290.00m,
                        Location = new LocationDto { Id = 114, Latitude = 45.8280, Longitude = 15.9433, Hotels = null }
                    },
                    new HotelDto
                    {
                        Id = 15,
                        Name = "Metro Budget Rooms",
                        Price = 70.00m,
                        Location = new LocationDto { Id = 115, Latitude = 45.8099, Longitude = 15.9755, Hotels = null }
                    }
                };
        }


    }
}
