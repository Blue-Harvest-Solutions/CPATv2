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
        [Display(Name ="Major")]
        public string MajorName { get; set; }

        public virtual ICollection<MajorCourse> MajorCourses { get; set; }
        
    }
}
