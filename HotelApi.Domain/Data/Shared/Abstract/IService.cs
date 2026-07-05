using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApi.Domain.Data.Shared.Abstract
{
    public interface IService<T>
    {
        T? Execute();
    }
}
