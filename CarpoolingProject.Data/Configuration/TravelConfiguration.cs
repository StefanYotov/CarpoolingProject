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
    public class TravelConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> travel)
        {
            travel
                .HasOne(t => t.StartPoint)
                .WithMany(t => t.TravelsWithStartingPoint)
                .HasForeignKey(a => a.StartPointId)
                .OnDelete(DeleteBehavior.NoAction);

            travel
                .HasOne(t => t.EndPoint)
                .WithMany(t => t.TravelsWithEndingPoint)
                .HasForeignKey(t => t.EndPointId)
                .OnDelete(DeleteBehavior.NoAction);

            //travel
            //    .HasMany(t => t.Passengers)
            //    .WithOne(p => p.Travel)
            //    .HasForeignKey(t => t.TravelId)
            //    .OnDelete(DeleteBehavior.NoAction);
                

        }
    }
}
