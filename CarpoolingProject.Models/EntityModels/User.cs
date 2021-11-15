using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarpoolingProject.Models.EntityModels
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Username must be {0}"), MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least {0} characters long!")]
        public string Password { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Firstname must be at least {0} characters long"), MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Lastname must be at least {0} characters long"), MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        public int TravelCountAsDriver { get; set; }
        public int StarsCount { get; set; }
        public int ReviewCount { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
        public virtual ICollection<TravelApplication> TravelApplicants { get; set; } = new List<TravelApplication>();


    }
}
