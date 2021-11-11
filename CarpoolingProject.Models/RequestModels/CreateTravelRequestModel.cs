using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.RequestModels
{
    public class CreateTravelRequestModel
    {
        public int UserId { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public int FreeSpots { get; set; }
    }
}
