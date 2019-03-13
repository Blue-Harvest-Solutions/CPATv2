using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class CoursesSelectedForTerm
    {
        public int Id { get; set; }

        public int PlanCourseId { get; set; }

        [ForeignKey("PlanCourseId")]
        public virtual Courses Courses { get; set; }
    }
}
