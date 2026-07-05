using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Domain.Data.Location.Dto
{
    public class LocationDto
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}