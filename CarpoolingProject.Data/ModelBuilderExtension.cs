using CarpoolingProject.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User
                {
                    UserId=1,
                    UserName="PeshoSalama",
                    Password="bezparola",
                    FirstName="Pesho",
                    LastName="Salama",
                    Email="pesho.salama@gmail.com",
                    PhoneNumber=088865432,
                    
                },
                new User
                {
                    UserId=2,
                    UserName="Customer",
                    Password="bezparola",
                    FirstName="Foncho",
                    LastName="Tarikata",
                    Email="foncho.tarikata@gmail.com",
                    PhoneNumber=088863432,
                    
                },
                new User
                {
                    UserId=3,
                    UserName="Shafior",
                    Password="bezparola",
                    FirstName="Lyubo",
                    LastName="Grigorov",
                    Email="lyubo.grigorov@gmail.com",
                    PhoneNumber=088845432,
                    
                }
            };
            var travels = new List<Travel>
            {
                new Travel
                {
                    TravelId=1,
                    StartPoint="velcho atanasov 55",
                    EndPoint ="Selo Sofia",
                    DepartureTime= new DateTime(2021, 11, 15, 22, 50,00),
                    FreeSpots= 4
                },
                new Travel
                {
                    TravelId=2,
                    StartPoint="velcho atanasov 55",
                    EndPoint ="Selo Sofia",
                    DepartureTime= new DateTime(2021, 11, 15, 22, 50,00),
                    FreeSpots= 2
                },
                new Travel
                {
                    TravelId=3,
                    StartPoint="velcho atanasov 55",
                    EndPoint ="Selo Sofia",
                    DepartureTime= new DateTime(2021, 11, 15, 22, 50,00),
                    FreeSpots= 3
                }
            };
            var roles = new List<Role>
            {
                new Role
                {
                    RoleId = 1,
                    Name = "Admin"

                },
                new Role
                {
                    RoleId = 2,
                    Name = "Driver"
                },
                new Role
                {
                    RoleId = 3,
                    Name = "Passanger"
                },
                new Role
                {
                    RoleId = 4,
                    Name = "Blocked"
                }
            };
            var userRoles = new List<UserRole>
            {
                new UserRole
                {
                    Id=1,
                    RoleId=1,
                    UserId=1
                },
                new UserRole
                {
                    Id=2,
                    RoleId=2,
                    UserId=2
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Travel>().HasData(travels);
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<UserRole>().HasData(userRoles);
            
        }
    }
}
