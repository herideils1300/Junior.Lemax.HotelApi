using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Domain.Business.Geometry
{
    public class GeometryCalcualtor
    {
        public GeometryCalcualtor()
        {
        }

        public double CalculateDistance(LocationDto first, LocationDto second)
        {
            double latitudeDistance = Math.Abs(first.Latitude - second.Latitude);
            double longitudeDistance = Math.Abs(first.Longitude - second.Longitude);
            return Math.Sqrt(Math.Pow(latitudeDistance, 2) + Math.Pow(longitudeDistance, 2));
        }

        public bool IsInDistance(LocationDto first, LocationDto second, double radius)
        {
            return CalculateDistance(first, second) < radius;
        }
    }
}
