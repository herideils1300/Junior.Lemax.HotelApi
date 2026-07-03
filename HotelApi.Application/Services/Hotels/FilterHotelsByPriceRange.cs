using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Business.Calculus;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Application.Services.Hotels
{
    public class FilterHotelsByPriceRange : IService<HotelDto[]>
    {

        private Calculator calculator;
        private double highBudget;
        private double lowBudget;
        private HotelDto[] hotels;
        public FilterHotelsByPriceRange()
        {
            calculator = new Calculator();
            hotels = Array.Empty<HotelDto>();
        }

        public void SetParams(HotelDto[] hotels, double lowBudget, double highBudget)
        {
            this.lowBudget = lowBudget;
            this.highBudget = highBudget;
            this.hotels = hotels;
        }

        public HotelDto[]? Execute()
        {
            if(lowBudget == 0 && highBudget == 0)
            {
                return hotels;
            }
            return hotels.Where(h => calculator.IsBetween(lowBudget, highBudget, (double)h.Price)).ToArray();
        }
    }
}
