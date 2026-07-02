using HotelApi.Domain.Data.Users.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("auth")]
        public ActionResult<UserReturnModel> AuthenticateUser(UserAuthModel model)
        {
            return new UserReturnModel();
        }

        [HttpPost]
        public ActionResult<UserReturnModel> RegisterUser(UserAuthModel request)
        {
            return new UserReturnModel();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(UserDto dto)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            return Ok();
        }

        [HttpPost("location")]
        public ActionResult UpdateLocation([FromBody] LocationParams location)
        {
            return Ok();
        }
    }
}
