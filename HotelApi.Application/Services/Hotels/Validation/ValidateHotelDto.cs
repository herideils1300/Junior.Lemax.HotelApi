using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Business.Validation;
using HotelApi.Domain.Business.Validation.Abstraction;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Application.Services.Hotels.Validation
{
    public class ValidateHotelDto : IApplicationService<string?>
    {
        private HotelDto hotel;
        private readonly IValidator<HotelDto> hotelValidator;

        public ValidateHotelDto() { 
            hotelValidator = new HotelDtoValidator();
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
