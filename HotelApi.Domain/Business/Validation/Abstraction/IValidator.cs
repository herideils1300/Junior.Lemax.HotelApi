using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApi.Domain.Business.Validation.Abstraction
{
    public interface IValidator<T> where T : class, new()
    {
        protected Dictionary<string, Predicate<T>> Conditions { get; }
        protected void BuildConditions();
        public string? ValidateWithError(T obj);
    }
}
