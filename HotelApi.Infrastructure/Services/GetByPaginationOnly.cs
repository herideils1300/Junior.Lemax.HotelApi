using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using HotelApi.Infrastructure.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Infrastructure.Services
{
    public class GetByPaginationOnly : IDbService<HotelDto[]>
    {
        private readonly MssqlDbContext _context;
        private HotelQuery query;
        public GetByPaginationOnly(MssqlDbContext context) { 
            this._context = context;
        }

        public void SetParams(HotelQuery query)
        {
            this.query = query;
        }
        public HotelDto[]? Execute()
        {
            HotelDto[] hotels = _context.Hotels.Include(hotel => hotel.Location)
                .Skip((this.query.Page - 1) * 10)
                .Take(10).ToArray();

            return hotels;
        }
    }
}
