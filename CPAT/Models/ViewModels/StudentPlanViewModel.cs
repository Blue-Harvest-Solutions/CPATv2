using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models.ViewModels
{
    public class StudentPlanViewModel
    {   
        public int Id { get; set; }

        public Students Student { get; set; }

        public IEnumerable<MajorRequirements> Major { get; set; }

        public ICollection<AcademicTerms> Terms { get; set; }

        public ICollection<Courses> Courses { get; set; }

    }
}
