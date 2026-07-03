using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelApi.Infrastructure.Persistance.Context.Variance
{
    public class PostgreSqlDbContext : GlobalContext
    {
        private readonly IConfiguration _configuration;

        public PostgreSqlDbContext(IConfiguration configuration) : base(new DbContextOptions<PostgreSqlDbContext>())
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresqlDefault") ?? "");
            }
        }
    }
}
