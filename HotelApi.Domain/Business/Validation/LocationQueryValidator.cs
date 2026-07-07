using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Domain.Business.Validation.Abstraction;
using HotelApi.Domain.Data.Location.Params;

namespace HotelApi.Domain.Business.Validation
{
    public class LocationQueryValidator : IValidator<LocationQuery>
    {
        private Dictionary<string, Predicate<LocationQuery>> conditions;

        public LocationQueryValidator()
        {
            conditions = new Dictionary<string, Predicate<LocationQuery>>();
            BuildConditions();
        }

        Dictionary<string, Predicate<LocationQuery>> IValidator<LocationQuery>.Conditions => throw new NotImplementedException();

        void IValidator<LocationQuery>.BuildConditions()
        {
            conditions.Clear();
        }

        private void BuildConditions()
        {
            //GOTO HotelQueryValidator.BuildConditions
            conditions.Clear();
            conditions.Add("Latitude is out of allowed range.",
                location => location.Latitude >= -90.0 && location.Latitude <= 90.0);
            conditions.Add("Longitude is out of allowed range.",
                location => location.Longitude >= -90.0 && location.Longitude <= 90.0);
        }

        public string? ValidateWithError(LocationQuery obj)
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
