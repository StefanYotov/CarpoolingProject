using CarpoolingProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.Dtos
{
    public class DriverDto
    {
        public DriverDto(User user)
        {
            Username = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            TravelCount = user.TravelCountAsDriver;
        }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TravelCount { get; set; }
    }
}
