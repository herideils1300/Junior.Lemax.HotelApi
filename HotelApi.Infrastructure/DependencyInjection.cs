using HotelApi.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelContext>((options) =>
            {
                switch (configuration.GetSection("db").GetSection("type").ToString())
                {
                    case "MSSQL":
                        options.UseSqlServer(configuration.GetConnectionString("mssql"));
                        break;
                    case "PostgreSQL":
                        options.UseNpgsql(configuration.GetConnectionString("postgresql"));
                        break;
                    case "SQLite":
                        options.UseSqlite(configuration.GetConnectionString(""));
                        break;
                    default:
                        throw new Exception("Type specified in sql options is not a valid type");


                }
            });
            return services;
        }
    }
}
