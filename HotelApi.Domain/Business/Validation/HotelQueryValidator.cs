using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Domain.Business.Validation.Abstraction;
using HotelApi.Domain.Data.Location.Params;

namespace HotelApi.Domain.Business.Validation
{
    public class HotelQueryValidator : IValidator<HotelQuery>
    {
        private Dictionary<string, Predicate<HotelQuery>> conditions;
        private IValidator<LocationQuery> queryValidator;

        public HotelQueryValidator()
        {
            queryValidator = new LocationQueryValidator();
            conditions = new Dictionary<string, Predicate<HotelQuery>>();
            BuildConditions();
        }

        Dictionary<string, Predicate<HotelQuery>> IValidator<HotelQuery>.Conditions { get => conditions; }
        public void BuildConditions()
        {
            //The error in the Key variable displays if the value condition FAILS to be aserted
            conditions = new Dictionary<string, Predicate<HotelQuery>>()
            {
                { "The lower budget cannot be higher than the higher budget", querry => (querry.LowBudget ?? 0) <= (querry.HighBudget ?? double.MaxValue)},
                { "Radius cannot be lesser than 0", querry => (querry.RadiusInMiles ?? 0) >= 0 },
                { "User location is invalid.", querry => queryValidator.ValidateWithError(querry.UserLocation) == null }
            };
        }

        public string? ValidateWithError(HotelQuery obj)
        {
            foreach (var condition in conditions)
            {
                if (!condition.Value(obj))
                {
                    return condition.Key;
                }
            }

            return null;
        }
    }
}
