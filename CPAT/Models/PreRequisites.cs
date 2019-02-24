using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class PreRequisites
    {
        public int Id { get; set; }

        public ICollection<Courses> PreReqs { get; set; }
    }
}
