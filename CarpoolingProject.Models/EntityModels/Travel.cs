using CarpoolingProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Data
{
    public class Travel
    {
        [Key]
        public int TravelId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public int FreeSpots { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
