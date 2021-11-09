using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.EntityModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Username must be {0}"), MaxLength(20)]
        public string Username { get; set; }
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

    }
}
