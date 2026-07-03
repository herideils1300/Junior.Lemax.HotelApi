using HotelApi.Domain.Data.Loaction.Dto;
using HotelApi.Domain.Data.Loaction.Params;

namespace HotelApi.Api
{
    public class HotelQuery
    {
        public LocationQuery UserLocation { get; set; }
        public int? RadiusInMiles { get; set; }
        public double? HighBudget { get; set; }
        public double? LowBudget { get; set; }

        public bool IsQueryNull()
        {
            return UserLocation == null || RadiusInMiles == null || HighBudget == null || LowBudget == null;
        }
    }
}