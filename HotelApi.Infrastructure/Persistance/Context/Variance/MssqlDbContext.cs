using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Infrastructure.Persistance.Context.Variance
{
    public class MssqlDbContext : GlobalContext
    {
        public MssqlDbContext()
                : base(new DbContextOptions<MssqlDbContext>())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=HotelDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
