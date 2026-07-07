using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Domain.Business.Validation.Abstraction;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Domain.Business.Validation
{
    public class HotelDtoValidator : IValidator<HotelDto>
    {

        private Dictionary<string, Predicate<HotelDto>> conditions;

        public HotelDtoValidator() : base()
        {
            BuildConditions();

        }

        //Explicit declaration
        Dictionary<string, Predicate<HotelDto>> IValidator<HotelDto>.Conditions { get => conditions; }

        void IValidator<HotelDto>.BuildConditions()
        {
            BuildConditions();
        }


        private void BuildConditions()
        {
            //GOTO HotelQueryValidator.BuildConditions
            conditions = new Dictionary<string, Predicate<HotelDto>>
            {
                { "Name is invalid", p => p.Name != null && p.Name.Length > 0 },
                { "Price is invalid", p => p.Price >= 0 },
                { "LocationLatitude is invalid", p => p.Location != null
                && p.Location.Latitude >= -90 && p.Location.Latitude <= 90 },
                { "Location is invalid", p => p.Location != null }
            };
        }

        public string? ValidateWithError(HotelDto obj)
        {
            foreach (var condition in conditions)
            {
                if (!condition.Value.Invoke(obj))
                {
                    return condition.Key;
                }
            }

            return null;
        }
    }
}
