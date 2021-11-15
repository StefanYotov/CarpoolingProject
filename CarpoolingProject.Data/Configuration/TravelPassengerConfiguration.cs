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
    public class TravelPassengerConfiguration : IEntityTypeConfiguration<TravelPassenger>
    {
        public void Configure(EntityTypeBuilder<TravelPassenger> travelPassenger)
        {
            travelPassenger
                .HasKey(t => new { t.PassengerId, t.TravelId });
            travelPassenger
                .HasOne(p => p.Passenger)
                .WithMany(p => p.PassengerForTravels)
                .HasForeignKey(p => p.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);
            
            travelPassenger
                .HasOne(p => p.Travel)
                .WithMany(p => p.Passengers)
                .HasForeignKey(p => p.TravelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
