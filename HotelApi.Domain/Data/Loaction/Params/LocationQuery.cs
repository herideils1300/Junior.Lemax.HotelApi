using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Domain.Data.Loaction.Dto;

namespace HotelApi.Domain.Data.Loaction.Params
{
    public class LocationQuery
    {
        public LocationQuery()
        {
        }

        public LocationQuery(LocationDto dto)
        {
            MapFromDto(dto);
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void MapFromDto(LocationDto dto)
        {
            Latitude = dto.Latitude;
            Longitude = dto.Longitude;
        }
    }
}
