using HotelApi.Application.Services.Abstract;
using HotelApi.Application.Services.Hotels.Pagination;
using HotelApi.Application.Services.Hotels.Sorting;
using HotelApi.Application.Services.Hotels.Validation;
using HotelApi.Domain.Data.Users.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ValidateHotelDto>();
            services.AddScoped<ValidateHotelQuery>();
            services.AddScoped<SortHotelsByDistance>();
            services.AddScoped<PaginateHotels>();

            return services;
        }
    }
}
