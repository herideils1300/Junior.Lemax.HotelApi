using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Application.Services.Hotels
{
    public class PaginateHotels : IApplicationService<HotelDto[]>
    {
        private HotelQuery query;
        private HotelDto[] hotels;
        public PaginateHotels() { }

        public void SetParams(HotelDto[] hotels, HotelQuery query)
        {
            this.query = query;
            this.hotels = hotels;
        }
        public HotelDto[]? Execute()
        {
            HotelDto[]? paginatedHotles = hotels.Skip((query.Page - 1) * query.Page).Take(10).ToArray();
            return paginatedHotles;
        }
    }
}
