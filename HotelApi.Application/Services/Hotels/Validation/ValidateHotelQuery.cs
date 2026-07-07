using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Application.Services.Abstract;
using HotelApi.Domain.Business.Validation;
using HotelApi.Domain.Business.Validation.Abstraction;

namespace HotelApi.Application.Services.Hotels.Validation
{
    public class ValidateHotelQuery : IApplicationService<string?>
    {
        private HotelQuery hotelQuery;
        private readonly IValidator<HotelQuery> validator;
        public ValidateHotelQuery()
        {
            validator = new HotelQueryValidator();
        }

        public void SetParams(HotelQuery hotelQuery)
        {
            this.hotelQuery = hotelQuery;
        }

        public string? Execute()
        {
            return validator.ValidateWithError(hotelQuery);
        }
    }
}
