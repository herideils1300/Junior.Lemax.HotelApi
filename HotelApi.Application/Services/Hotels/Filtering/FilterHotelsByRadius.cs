using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Business.Geometry;
using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Application.Services.Hotels.Filtering
{
    public class FilterHotelsByRadius : IService<HotelDto[]>
    {
        private readonly GeometryCalcualtor calcultor;
        private readonly LocationDto userLocation;
        private readonly HotelDto[] hotels;
        private readonly double radius;

        public FilterHotelsByRadius(GeometryCalcualtor calcultor, LocationDto userLocation, HotelDto[] hotels, double radius)
        {
            this.calcultor = calcultor;
            this.userLocation = userLocation;
            this.hotels = hotels;
            this.radius = radius;
        }

        public HotelDto[]? Execute(dynamic input)
        {
            var hotelsInRadius = hotels.Where((hotel) => calcultor.IsInDistance(userLocation, hotel.Location, radius));
            return hotelsInRadius.ToArray();
        }
    }
}
