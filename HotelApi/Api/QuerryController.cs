using HotelApi.Infrastructure.Services;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Mvc;
using HotelApi.Application.Services.Hotels.Validation;
using HotelApi.Application.Services.Hotels.Pagination;
using HotelApi.Application.Services.Hotels.Sorting;
using HotelApi.Domain.Business.Logging;
using Microsoft.AspNetCore.Authorization;

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuerryController : ControllerBase
    {
        private readonly SortHotelsByDistance _distanceSort;
        private readonly GetHotelsByRadiusAndPrice _getByPriceAndRadius;
        private readonly GetByPaginationOnly _getByPagination;
        private readonly PaginateHotels _paginateHotels;
        private readonly ValidateHotelQuery _validate;

        public QuerryController(SortHotelsByDistance distanceSort,
            GetHotelsByRadiusAndPrice filterByRadius,
            GetByPaginationOnly getByPagination,
            PaginateHotels paginateHotels,
            ValidateHotelQuery validate)
        {
            _distanceSort = distanceSort;
            _getByPriceAndRadius = filterByRadius;
            _getByPagination = getByPagination;
            _paginateHotels = paginateHotels;
            _validate = validate;
        }

        [HttpPost]
        public ActionResult<HotelDto[]> QueryHotels([FromBody] HotelQuery query)
        {
            try
            {
                _validate.SetParams(query);
                string? error = _validate.Execute();
                if (error != null)
                {
                    Console.Error.WriteLine(error);
                    _getByPagination.SetParams(query);
                    var allHotels = _getByPagination.Execute();
                    return Ok(allHotels);
                }

                _getByPriceAndRadius.SetParameters(query);
                HotelDto[]? hotels = _getByPriceAndRadius.Execute();

                _distanceSort.SetParams(hotels!, query.UserLocation);
                hotels = _distanceSort.Execute();

                _paginateHotels.SetParams(hotels!, query);
                hotels = _paginateHotels.Execute();

                return Ok(hotels);
            }
            catch (Exception e)
            {

                CustomLogger.LogException(e);
                return StatusCode(500);
            }
        }
    }
}
