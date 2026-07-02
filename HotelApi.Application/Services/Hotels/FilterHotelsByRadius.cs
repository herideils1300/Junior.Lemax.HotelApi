using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Business.Geometry;
using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Loaction.Params;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Application.Services.Hotels
{
    public class FilterHotelsByRadius : IService<HotelDto[]>
    {
        private Calculator calcultor;
        private LocationQuery userLocation;
        private HotelDto[] hotels;
        private double radius;

        public FilterHotelsByRadius()
        {
            this.calcultor = new Calculator();
        }

        public void SetParams(LocationQuery userLocation, HotelDto[] hotels, double radius)
        {
            this.userLocation = userLocation;
            this.hotels = hotels;
            this.radius = radius;
        }

        public HotelDto[]? Execute()
        {
            var filteredHotels = hotels.Where((hotel) => calcultor.IsInRange(userLocation, new LocationQuery(hotel.Location), radius));
            return filteredHotels.ToArray();
        }
    }
}
