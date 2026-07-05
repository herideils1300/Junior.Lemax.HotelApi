using HotelApi.Application.Services.Hotels.Services;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerryController : ControllerBase
    {

        private readonly MssqlDbContext _context;
        private readonly SortHotelsByDistance _distanceSort;
        private readonly FilterByRadiusAndPrice _filterByRadiusAndPrice;

        public QuerryController(MssqlDbContext context, 
            SortHotelsByDistance distanceSort,
            FilterByRadiusAndPrice filterByRadius)
        {
            _context = context;
            _distanceSort = distanceSort;
            _filterByRadiusAndPrice = filterByRadius;
        }

        [HttpPost]
        public ActionResult<HotelDto[]> QueryHotels([FromBody] HotelQuery query)
        {
            if (query == null)
            {
                return BadRequest("Query cannot be null.");
            }

            _filterByRadiusAndPrice.SetParameters(_context, query);
            HotelDto[]? filteredHotels = _filterByRadiusAndPrice.Execute();

            _distanceSort.SetParams(filteredHotels!.ToArray(), query.UserLocation);
            HotelDto[]? sortedHotels = _distanceSort.Execute();

            return Ok(sortedHotels);
        }
    }
}
