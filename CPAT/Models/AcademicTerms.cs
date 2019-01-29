using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class AcademicTerms
    {
        public int Id { get; set; }

        [Required]
        public int Season { get; set; }

        [Required]
        public string Year { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Courses Courses { get; set; }
    }
}
