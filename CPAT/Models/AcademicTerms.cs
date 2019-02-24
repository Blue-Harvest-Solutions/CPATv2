using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public enum Season
    {
        [Description("Not Currently Offered")]
        None,
        [Description("Spring")]
        Spring,
        [Description("Summer")]
        Summer,
        [Description("Fall")]
        Fall,
        [Description("Fall and Spring")]
        FaSp,
        [Description("Fall, Spring, and Summer")]
        FaSpSu,
        [Description("Spring and Summer")]
        SpSu,
        [Description("Summer and Fall")]
        SuFa
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
