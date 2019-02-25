using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class MajorCourse
    {
        public int MajorRequirementsId { get; set; }
        public MajorRequirements MajorRequirements { get; set; }

        public int CoursesId { get; set; }
        public Courses Courses { get; set; }

    }
}
