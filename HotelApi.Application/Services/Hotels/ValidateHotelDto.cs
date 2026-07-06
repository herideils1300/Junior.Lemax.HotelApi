using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Business.Validation;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Application.Services.Hotels
{
    public class ValidateHotelDto : IApplicationService<string?>
    {
        private HotelDto hotel;
        private readonly HotelDtoValidator hotelValidator;

        public ValidateHotelDto() { 
            this.hotelValidator = new HotelDtoValidator();
        }

        public void SetParams(HotelDto hotel)
        {
            this.hotel = hotel;
        }

        public string? Execute()
        {
            return hotelValidator.ValidateWithError(hotel);
        }
    }
}
