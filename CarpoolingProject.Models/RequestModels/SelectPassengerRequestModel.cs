using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.RequestModels
{
    public class SelectPassengerRequestModel
    {
        public int TravelId { get; set; }
        public int Id { get; set; }
        public bool Liked { get; set; }
    }
}
