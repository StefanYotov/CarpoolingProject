using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CarpoolingProject.Models.EntityModels
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        public string StreetName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public virtual ICollection<Travel> TravelsWithStartingPoint { get; set; }
        public virtual ICollection<Travel> TravelsWithEndingPoint { get; set; }
    }
}