using HotelListing.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser> //we have used ApiUser class here because we
                                                              //inherited the IdentityUser class to ApiUser
                                                              //to add extra fields other then default
                                                              //identityclass like FirstName and Last Name
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.ApplyConfiguration(new CountryConfiguration());//moved the configuration to a separate class CountryConfiguration

            //not creating a separate class for Hotel configuration, to be understandable the approach of configuration is a sperate file as we did above for Country and Role
            builder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "PakistanHotel", Address = "Kohat", CountryId = 1, Rating = 4.5 },
                new Hotel { Id = 2, Name = "TurkeyHotel", Address = "Istanbul", CountryId = 2, Rating = 4.5 },
                new Hotel { Id = 3, Name = "SaudiArabiaHotel", Address = "Riyadh", CountryId = 2, Rating = 4.5 });
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
