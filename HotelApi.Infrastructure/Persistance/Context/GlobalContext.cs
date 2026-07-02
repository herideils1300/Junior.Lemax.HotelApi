using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Domain.Data.Users.Dto;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Infrastructure.Persistance.Context
{
    public class GlobalContext : DbContext
    {
        public GlobalContext(DbContextOptions options) : base(options)
        {
        }

        protected GlobalContext()
        {
        }

        public DbSet<HotelDto> Hotels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Link between a hotel and a Location
            modelBuilder.Entity<HotelDto>().HasOne(hotel => hotel.Location);
        }
    }
}
