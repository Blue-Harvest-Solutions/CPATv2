using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class Courses
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Course ID")]
        public string CourseID { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        public int? CreditHours { get; set; }

        [Display(Name = "Estimated Season Availability")]
        public int? SeasonAvailability { get; set; }
    }
}
