using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Api;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Users.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelApi.Infrastructure.Persistance.Context
{
    public class GlobalContext : DbContext
    {
        public GlobalContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<HotelDto> Hotels { get; set; }
        public DbSet<LocationDto> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<HotelDto>().HasKey(x => x.Id);
            modelBuilder.Entity<LocationDto>().HasKey(x => x.Id);

            //Link between a hotel and a Location
            modelBuilder.Entity<HotelDto>().HasOne(hotel => hotel.Location).WithMany();
        }
    }
}
