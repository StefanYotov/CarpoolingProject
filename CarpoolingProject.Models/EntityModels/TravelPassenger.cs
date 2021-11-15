using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.EntityModels
{
    public class TravelPassenger
    {
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        public int PassengerId { get; set; }
        public User Passenger { get; set; }
    }
}
