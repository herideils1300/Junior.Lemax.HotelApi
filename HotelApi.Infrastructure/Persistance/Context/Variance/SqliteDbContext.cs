using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Infrastructure.Persistance.Context.Variance
{
    public class SqliteDbContext : GlobalContext
    {
        public SqliteDbContext()
            : base(new DbContextOptions<SqliteDbContext>())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=hotel.db");
            }
        }
    }
}
