using CarpoolingProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.RequestModels
{
    public class CreateTravelRequestModel
    {
        public int CreatorId { get; set; }
        public Address StartPoint { get; set; }
        public Address EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public int FreeSpots { get; set; }
    }
}
