using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class AcademicTerms
    {
        public int Id { get; set; }

        [Range(0,7)]
        [Required]
        public int Season { get; set; }

        [Required]
        public string Year { get; set; }

        public ICollection<Courses> TermCourses { get; set; }
    }
}
