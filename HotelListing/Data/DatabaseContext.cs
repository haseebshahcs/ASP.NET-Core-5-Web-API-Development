using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Pakistan", ShortName = "Pak" },
                new Country { Id = 2, Name = "Turkey", ShortName = "Tur" },
                new Country { Id = 3, Name = "SaudiArabia", ShortName = "Ksa" });
            builder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "PakistanHotel", Address = "Kohat", CountryId = 1, Rating = 4.5 },
                new Hotel { Id = 2, Name = "TurkeyHotel", Address = "Istanbul", CountryId = 2, Rating = 4.5 },
                new Hotel { Id = 3, Name = "SaudiArabiaHotel", Address = "Riyadh", CountryId = 2, Rating = 4.5 });
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
