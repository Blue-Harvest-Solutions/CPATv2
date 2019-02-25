using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class StudentPlans
    {
        public int Id { get; set; }

        public virtual ICollection<CourseTerm> Terms { get; set; }

        /*
       [Display(Name = "Student")]
       public int StudentId { get; set; }

       [ForeignKey("StudentId")]
       public virtual Students Students { get; set; }
       */

        /*
        [Display(Name = "Major")]
        public int MajorId { get; set; }

        [ForeignKey("MajorId")]
        public virtual MajorRequirements MajorRequirements { get; set; }
        */
    }
}
