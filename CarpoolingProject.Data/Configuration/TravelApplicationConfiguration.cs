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
    public class TravelApplicationConfiguration : IEntityTypeConfiguration<TravelApplication>
    {
        public void Configure(EntityTypeBuilder<TravelApplication> travelApplication)
        {
            travelApplication
                 .HasKey(t => new { t.ApplicantId, t.TravelId });

            travelApplication
                .HasOne(t => t.Applicant)
                .WithMany(u => u.TravelApplications)
                .HasForeignKey(t => t.ApplicantId)
                .OnDelete(DeleteBehavior.NoAction);

            travelApplication
                .HasOne(ta => ta.Travel)
                .WithMany(t => t.ApplicantsForTravel)
                .HasForeignKey(ta => ta.TravelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
