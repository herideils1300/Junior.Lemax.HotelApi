using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelApi.Infrastructure.Persistance.Context.Variance
{
    public class MssqlDbContext : GlobalContext
    {
        private readonly IConfiguration _config;
        public MssqlDbContext(IConfiguration config)
                : base(new DbContextOptions<MssqlDbContext>())
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _config.GetConnectionString("DefaultMssql")
                    );
            }
        }
    }
}
