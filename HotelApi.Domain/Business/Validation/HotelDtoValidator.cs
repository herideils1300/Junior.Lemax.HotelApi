using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Domain.Business.Validation.Abstraction;
using HotelApi.Domain.Data.Users.Dto;

namespace HotelApi.Domain.Business.Validation
{
    public class HotelDtoValidator : IValidator<HotelDto>
    {

        private Dictionary<string, Predicate<HotelDto>> conditions;

        public HotelDtoValidator() : base() {
            conditions = new Dictionary<string, Predicate<HotelDto>>();
            BuildConditions();
            
        }

        //Explicit declaration
        Dictionary<string, Predicate<HotelDto>> IValidator<HotelDto>.Conditions { get => conditions; set => value = conditions; }

        void IValidator<HotelDto>.BuildConditions()
        {
            BuildConditions();
        }


        //Implementation
        public string? ValidateWithError(HotelDto obj)
        {
            if(obj == null)
            {
                return "Object passed to endpoint cannot be null";
            }


            foreach (KeyValuePair<string, Predicate<HotelDto>> condition in conditions)
            {
                if (!condition.Value(obj))
                {
                    return condition.Key;
                }
            }
            return null;
        }

        private void BuildConditions()
        {
            conditions = new Dictionary<string, Predicate<HotelDto>>
            {
                {"Name is invalid", p => p.Name != null && p.Name.Length > 0 },
                {"Price is invalid", p => p.Price >= 0 },
                {"LocationLatitude is invalid", p => p.Location != null 
                && p.Location.Latitude >= -90 && p.Location.Latitude <= 90 },
                {"Location is invalid", p => p.Location != null }
            };
        }
    }
}
