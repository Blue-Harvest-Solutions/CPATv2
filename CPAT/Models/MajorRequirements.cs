using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class MajorRequirements
    {
        public int Id { get; set; }

        [Required]
        public string MajorName { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Courses Courses { get; set; }
    }
}
