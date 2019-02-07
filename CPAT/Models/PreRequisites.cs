using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class PreRequisites
    {
        public int Id { get; set; }

        public IEnumerable<Courses> PreReqs { get; set; }
    }
}
