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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> userRole)
        {
            userRole
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            userRole
                .HasOne(ur => ur.Role)
                .WithMany(ur => ur.Users)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
            userRole
                .HasOne(ur => ur.User)
                .WithMany(ur => ur.Roles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
