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
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> rating)
        {
            rating
                .HasOne(r => r.RatedUser)
                .WithMany(r => r.RatingsForUser)
                .HasForeignKey(r => r.RatedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            rating
                .HasOne(r => r.Author)
                .WithMany(r => r.CreatedRatings)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
