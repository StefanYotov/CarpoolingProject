using CarpoolingProject.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> city)
        {
            city
               .HasOne(c => c.Country)
               .WithMany(ci => ci.Cities)
               .HasForeignKey(c => c.CountryId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
