using System.Diagnostics;
using System.Linq;
using HotelApi.Application.Services.Hotels;
using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


            var hotels = from hotel in _context.Hotels
                         join queryLocation in _context.Locations on hotel.Location equals queryLocation
                         select hotel;

            //TODO: Cover use cases when query params might be null
            _radiusFilter.SetParams(query.UserLocation, hotels.ToArray(), query.RadiusInKm ?? 0);
            _priceFilter.SetParams(hotels.ToArray(), query.LowBudget ?? 0, query.HighBudget ?? 0);

            var filteredHotels = _radiusFilter.Execute();

            return Ok();
        }
    }
}
