using HotelApi.Api;
using HotelApi.Domain.Business.Calculus;
using HotelApi.Domain.Data.Location.Params;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using HotelApi.Infrastructure.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Infrastructure.Services;

public class GetHotelsByRadiusAndPrice : IDbService<HotelDto[]>
{
    private readonly Calculator calculator;
    private HotelQuery query;
    private readonly MssqlDbContext _context;
    public GetHotelsByRadiusAndPrice(MssqlDbContext context)
    {
        _context = context;
        this.calculator = new Calculator();
    }

    public void SetParameters(HotelQuery query)
    {
        this.query = query;
    }

    public HotelDto[]? Execute()
    {
        return _context.Hotels
            .Where(hotel => (double)hotel.Price < query.HighBudget && (double)hotel.Price > query.LowBudget)
            .Include(hotel => hotel.Location)
            .AsEnumerable()
            .Where(hotel => calculator.CalculateDistance(query.UserLocation, new LocationQuery(hotel.Location)) < query.RadiusInMiles)
            .ToArray();
    }
}
