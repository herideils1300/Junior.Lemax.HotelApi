using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelApi.Infrastructure.Persistance.Context.Variance
{
    public class PostgreSqlDbContext : GlobalContext
    {
        private readonly IConfiguration _config;
        public PostgreSqlDbContext(IConfiguration config) : base(new DbContextOptions<PostgreSqlDbContext>())
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_config.GetConnectionString("PostgresqlDefault") ?? "");
            }
        }
    }
}
