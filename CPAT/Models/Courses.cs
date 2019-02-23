using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 12)]
        [Display(Name = "Credit Hours")]
        public int? CreditHours { get; set; }

        
        [Display(Name = "Estimated Season Availability")]
        public Season EstSeason { get; set; }

        [Display(Name = "Include in Major?")]
        public bool IncludeInMajor { get; set; }

        [Display(Name = "Complete?")]
        public bool IsComplete { get; set; }

        [Display(Name = "In Progress")]
        public bool InProgress { get; set; }

        [Display(Name = "Link to Course Details")]
        public string DetailsLink { get; set; }

        /*
        [Display(Name = "Pre-requisites")]
        public PreRequisites PreRequisites { get; set; }
        

        [Display(Name = "Major")]
        public int MajorId { get; set; }

        [ForeignKey("MajorId")]
        public virtual MajorRequirements MajorReference { get; set; }
        */
    }
}
