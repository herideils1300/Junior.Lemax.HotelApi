using HotelApi.Application.Services.Abstract;
using HotelApi.Application.Services.Hotels.Services;
using HotelApi.Domain.Data.Users.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<SortHotelsByDistance>();
            return services;
        }
    }
}
