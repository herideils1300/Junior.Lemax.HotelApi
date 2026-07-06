using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Domain.Data.Location.Dto;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Domain.Data.Users.Dto
{
    [Index(nameof(Price), IsUnique = false, Name = "IX_Hotel_Price")]
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public LocationDto Location { get; set; } = new();
    }
}
