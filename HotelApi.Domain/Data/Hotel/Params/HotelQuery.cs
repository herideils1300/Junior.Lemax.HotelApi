using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Loaction.Params;

namespace HotelApi.Api
{
    public class HotelQuery
    {
        public LocationQuery UserLocation { get; set; }
        public int? RadiusInKm { get; set; }
        public double? HighBudget { get; set; }
        public double? LowBudget { get; set; }
    }
}