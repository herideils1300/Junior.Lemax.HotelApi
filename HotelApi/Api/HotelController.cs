using HotelApi.Domain.Data.Users.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        [HttpPost]
        public ActionResult<HotelDto[]> QueryHotels([FromBody] HotelQuery query)
        {
            return Ok();
        }
    }
}
