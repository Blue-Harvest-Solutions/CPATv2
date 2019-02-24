using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public enum Season
    {
        None, Spring, Summer, Fall, FS, FSSu, SSu, SuF
    }

    public class AcademicTerms
    {
        public int Id { get; set; }

        public Season Season { get; set; }

        [Required]
        public DateTime Year { get; set; }

        public ICollection<Courses> TermCourses { get; set; }
    }
}
