using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Loaction.Params;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Domain.Business.Calculus
{
    public class Calculator
    {

        private double CalculateDistance(LocationQuery first, LocationQuery second)
        {
            double latitudeDistance = Math.Abs(first.Latitude - second.Latitude);
            double longitudeDistance = Math.Abs(first.Longitude - second.Longitude);
            return Math.Sqrt(Math.Pow(latitudeDistance, 2) + Math.Pow(longitudeDistance, 2));
        }

        public bool IsInRange(LocationQuery first, LocationQuery second, double radius)
        {
            return CalculateDistance(first, second) < radius;
        }

        public bool IsBetween(double lower, double upper, double price)
        {
            return (price <= upper) && (price >= lower);
        }
    }
}
