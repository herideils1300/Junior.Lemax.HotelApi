using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Location.Params;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Domain.Business.Calculus
{
    public class Calculator
    {

        public double CalculateDistance(LocationQuery first, LocationQuery second)
        {
            double latitudeDistance = Math.Abs(first.Latitude - second.Latitude);
            double longitudeDistance = Math.Abs(first.Longitude - second.Longitude);
            return Math.Sqrt(Math.Pow(latitudeDistance, 2) + Math.Pow(longitudeDistance, 2));
        }

        public int DetermineLocationSort(LocationQuery userLocation, LocationQuery first, LocationQuery second)
        {
            return (CalculateDistance(userLocation, first) < CalculateDistance(userLocation, second)) ? -1 : 1;
        }

    }
}
