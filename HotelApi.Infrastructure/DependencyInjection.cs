using HotelApi.Infrastructure.Persistance.Context;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using HotelApi.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddScoped<GetFilterByRadiusAndPrice>();
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GlobalContext>();
            services.AddDbContext<MssqlDbContext>();
            return services;
        }
    }
}
