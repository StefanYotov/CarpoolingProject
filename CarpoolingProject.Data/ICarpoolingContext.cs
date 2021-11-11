using CarpoolingProject.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace CarpoolingProject.Data
{
    public interface ICarpoolingContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Travel> Travels { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Address> Addresses { get; set; }
    }
}
