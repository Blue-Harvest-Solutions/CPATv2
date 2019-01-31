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
        [Display(Name = "Credit Hours")]
        public int? CreditHours { get; set; }

        [Display(Name = "Estimated Season Availability")]
        public int? SeasonAvailability { get; set; }

        [Display(Name = "Include in Major?")]
        public bool IncludeInMajor { get; set; }

        [Display(Name = "Complete?")]
        public bool IsComplete { get; set; }

        [Display(Name = "In Progress")]
        public bool InProgress { get; set; }

        [Display(Name = "Academic Term")]
        public int AcademicTermId { get; set; }

        [ForeignKey("AcademicTermId")]
        public virtual AcademicTerms AcademicTerms { get; set; }

        [Display(Name = "Major")]
        public int MajorRequirementsId { get; set; }

        [ForeignKey("MajorRequirementsId")]
        public virtual MajorRequirements MajorRequirements { get; set; }
    }
}
