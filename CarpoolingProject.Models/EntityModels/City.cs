using System.ComponentModel.DataAnnotations;

namespace CarpoolingProject.Models.EntityModels
{
    public class City
    {
        
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
