using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.EntityModels
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
