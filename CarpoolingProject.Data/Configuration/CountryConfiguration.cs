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
    public class CountryConfiguration: IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> country)
        {
            country
                .HasMany(c => c.Cities)
                .WithOne(ci => ci.Country)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
