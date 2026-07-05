using HotelApi.Api;
using HotelApi.Domain.Business.Calculus;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Location.Params;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using HotelApi.Infrastructure.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Application.Services.Hotels.Services
{
    public class FilterByRadiusAndPrice : IDbService<HotelDto[]>
    {
        private readonly Calculator calculator;
        private HotelQuery query;
        private MssqlDbContext hotels;
        public FilterByRadiusAndPrice()
        {
            this.calculator = new Calculator();
        }

        public void SetParameters(MssqlDbContext globalContext, HotelQuery query)
        {
            this.query = query;
            this.hotels = globalContext;
        }

        public HotelDto[]? Execute()
        {
            return hotels.Hotels
                .Where(hotel => hotel.Price < (decimal)(query.HighBudget ?? double.MaxValue) && hotel.Price > (decimal)(query.LowBudget ?? 0.0))
                .Include(hotel => hotel.Location)
                .AsEnumerable()
                .Where(hotel => calculator.CalculateDistance(query.UserLocation, new LocationQuery(hotel.Location)) < query.RadiusInMiles)
                .ToArray();
        }
    }
}
