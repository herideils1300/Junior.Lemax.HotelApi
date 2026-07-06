using HotelApi.Infrastructure.Services;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Mvc;
using HotelApi.Application.Services.Hotels;

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerryController : ControllerBase
    {

        private readonly MssqlDbContext _context;
        private readonly SortHotelsByDistance _distanceSort;
        private readonly GetFilterByRadiusAndPrice _getFilteredByPrice;
        private readonly PaginateHotels _paginateHotels;

        public QuerryController(MssqlDbContext context,
            SortHotelsByDistance distanceSort,
            GetFilterByRadiusAndPrice filterByRadius,
            PaginateHotels paginateHotels)
        {
            _context = context;
            _distanceSort = distanceSort;
            _getFilteredByPrice = filterByRadius;
            _paginateHotels = paginateHotels;
        }

        [HttpPost]
        public ActionResult<HotelDto[]> QueryHotels([FromBody] HotelQuery query)
        {

            _getFilteredByPrice.SetParameters(_context, query);
            HotelDto[]? hotels = _getFilteredByPrice.Execute();

            _distanceSort.SetParams(hotels!, query.UserLocation);
            hotels = _distanceSort.Execute();

            _paginateHotels.SetParams(hotels!, query);
            hotels = _paginateHotels.Execute();

            return Ok(hotels);
        }
    }
}
