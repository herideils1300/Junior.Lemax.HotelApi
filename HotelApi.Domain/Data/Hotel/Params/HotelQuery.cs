using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Location.Params;

namespace HotelApi.Api
{
    public class HotelQuery
    {
        public LocationQuery UserLocation { get; set; }
        public double? RadiusInMiles { get; set; }
        public double? HighBudget { get; set; }
        public double? LowBudget { get; set; }

        public bool IsQueryNull()
        {
            return UserLocation == null || RadiusInMiles == null || HighBudget == null || LowBudget == null;
        }
    }
}