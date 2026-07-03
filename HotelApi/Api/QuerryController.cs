using System.Diagnostics;
using System.Linq;
using HotelApi.Application.Services.Hotels;
using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SQLitePCL;

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerryController : ControllerBase
    {

        private readonly MssqlDbContext _context;
        private readonly FilterHotelsByRadius _radiusFilter;
        private readonly FilterHotelsByPriceRange _priceFilter;

        public QuerryController(MssqlDbContext context, FilterHotelsByRadius radiusFilter, FilterHotelsByPriceRange priceFilter)
        {
            _context = context;
            _radiusFilter = radiusFilter;
            _priceFilter = priceFilter;
        }

        [HttpPost]
        public ActionResult<HotelDto[]> QueryHotels([FromBody] HotelQuery query)
        {
            if (query == null)
            {
                return BadRequest("Query cannot be null.");
            }

            var hotels = _context.Hotels.Include(hotel => hotel.Location).ToArray();

            _radiusFilter.SetParams(query.UserLocation, hotels.ToArray(), query.RadiusInMiles ?? 0);
            HotelDto[]? radiusFilteredHotels = _radiusFilter.Execute();

            _priceFilter.SetParams(radiusFilteredHotels!, query.LowBudget ?? 0, query.HighBudget ?? 0);
            HotelDto[]? fullyFilteredHotels = _priceFilter.Execute();

            return Ok(fullyFilteredHotels);
        }
    }
}
