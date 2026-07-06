using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApi.Domain.Business.Validation.Abstraction
{
    public interface IValidator<T>
    {
        public Dictionary<string, Predicate<T>> Conditions { get; set; }
        protected void BuildConditions();
        string? ValidateWithError(T obj);
    }
}
