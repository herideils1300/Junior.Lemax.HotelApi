using HotelApi.Domain.Data.Loaction.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        [HttpPost]
        public ActionResult<HotelQuery> PostLocation(LocationDto location)
        {

            return Ok();
        }
    }
}
