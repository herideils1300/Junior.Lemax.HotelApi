using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelApi.Infrastructure.Persistance.Context.Variance
{
    public class SqliteDbContext : GlobalContext
    {
        private readonly IConfiguration _configuration;
        public SqliteDbContext(IConfiguration configuration)
            : base(new DbContextOptions<SqliteDbContext>())
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteDefault") ?? "");
            }
        }
    }
}
