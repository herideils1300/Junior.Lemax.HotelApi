using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Infrastructure.Persistance.Context.Variance
{
    public class PostgreSqlDbContext : GlobalContext
    {
        public PostgreSqlDbContext()
            : base(new DbContextOptions<PostgreSqlDbContext>())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Database=HotelDb;Username=postgres;Password=password");
            }
        }
    }
}
