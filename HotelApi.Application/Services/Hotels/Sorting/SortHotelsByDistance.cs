using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Business.Calculus;
using HotelApi.Domain.Data.Location.Params;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Application.Services.Hotels.Sorting
{
    public class SortHotelsByDistance : IApplicationService<HotelDto[]>
    {

        private Calculator calculator;
        private HotelDto[] hotels;
        private LocationQuery userLocation;
        public SortHotelsByDistance()
        {
            calculator = new Calculator();
            hotels = Array.Empty<HotelDto>();
        }

        public void SetParams(HotelDto[] hotels, LocationQuery userLocation)
        {
            this.hotels = hotels;
            this.userLocation = userLocation;
        }

        public HotelDto[]? Execute()
        {
            List<HotelDto> listHotels = hotels.ToList();

            listHotels
                .Sort((first, second) => calculator.DetermineLocationSort(
                    userLocation,
                    new LocationQuery(first.Location),
                    new LocationQuery(second.Location)));

            return listHotels.ToArray();
        }
    }
}
