using CarpoolingProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.EntityModels
{
    public class Travel
    {
        [Key]
        public int TravelId { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        [Required]
        public Address StartPoint { get; set; }
        public int StartPointId { get; set; }
        [Required]
        public Address EndPoint { get; set; }
        public int EndPointId { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public int FreeSpots { get; set; }
        public virtual ICollection<TravelPassenger> Passengers { get; set; } = new List<TravelPassenger>();
        public ICollection<TravelApplication> ApplicantsForTravel { get; set; }
    }
}
