using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Location.Params;

namespace HotelApi.Api
{
    public class HotelQuery
    {

        private double radiusInMiles = double.MaxValue;
        private double highBudget = double.MaxValue;
        private double lowBudget = 0.0;
        public LocationQuery UserLocation { get; set; }
        public double? RadiusInMiles { get => radiusInMiles; set => radiusInMiles = (value == null) ? double.MaxValue : (double)value; }
        public double? HighBudget { get => highBudget; set => highBudget = (value == null) ? double.MaxValue : (double)value; }
        public double? LowBudget { get => lowBudget; set => lowBudget = (value == null) ? 0.0 : (double)value; }
        public int Page { get; set; }

        public bool IsQueryNull()
        {
            return UserLocation == null || RadiusInMiles == null || HighBudget == null || LowBudget == null;
        }
    }
}