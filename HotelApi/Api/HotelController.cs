using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly MssqlDbContext _context;

        public HotelController(MssqlDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelDto>> Get()
        {
            try
            {
                IEnumerable<HotelDto> hotels = _context.Hotels.Include<HotelDto, LocationDto>(hotel => hotel.Location).AsEnumerable();

                return Ok(hotels);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<HotelDto> Get(int id)
        {
            try
            {
                HotelDto hotel = _context.Hotels
                    .Include<HotelDto, LocationDto>(hotel => hotel.Location)
                    .Where(x => x.Id == id)
                    .First();

                if (hotel == null)
                    return NotFound();

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<HotelDto> Post([FromBody] HotelDto hotel)
        {
            try
            {
                if (hotel == null)
                    return BadRequest();

                _context.Hotels.Add(hotel);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<HotelDto> Put(int id, [FromBody] HotelDto hotel)
        {
            try
            {
                if (hotel == null)
                    return BadRequest();

                var existingHotel = _context.Hotels.Find(id);

                if (existingHotel == null)
                    return NotFound();

                existingHotel.Name = hotel.Name;
                existingHotel.Price = hotel.Price;

                if (_context.Locations.Where(location => location.Latitude == existingHotel.Location.Latitude
                && location.Longitude == existingHotel.Location.Longitude).IsNullOrEmpty())
                {
                    existingHotel.Location = hotel.Location;
                }
                else
                {
                    existingHotel.Location = hotel.Location;
                }


                    _context.SaveChanges();

                return Ok(existingHotel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var hotel = _context.Hotels.Find(id);

                if (hotel == null)
                    return NotFound();

                _context.Hotels.Remove(hotel);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
