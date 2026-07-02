using HotelApi.Application.Services.Hotels;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<FilterHotelsByRadius>();
            services.AddScoped<FilterHotelsByPriceRange>();
            return services;
        }
    }
}
