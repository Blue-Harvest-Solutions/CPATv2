using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models.ViewModels
{
    public class MajorRequirementsViewModel
    {
        public MajorRequirements MajorRequirements { get; set; }

        public IEnumerable<Courses> Courses { get; set; }
    }
}
