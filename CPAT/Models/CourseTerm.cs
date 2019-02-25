using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class CourseTerm
    {
        public int CoursesId { get; set; }
        public Courses Courses { get; set; }

        public int AcademicTermsId { get; set; }
        public AcademicTerms Terms { get; set; }

        public bool? IsComplete { get; set; } = false;
        public bool? InProgress { get; set; } = false;
        public bool Attempted { get; set; } = false;
    }
}
