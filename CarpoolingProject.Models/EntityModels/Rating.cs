using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.EntityModels
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int RatedUserId { get; set; }
        public User RatedUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
        public bool IsChanged { get; set; }
        public int StarsCount { get; set; }

    }
}
