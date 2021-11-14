using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.EntityModels
{
    public class TravelApplication
    {
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        public int ApplicantId { get; set; }
        public User Applicant { get; set; }
    }
}
