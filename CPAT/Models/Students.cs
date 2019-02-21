using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Models
{
    public class Students
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "N Number")]
        public string N_Number { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        public char MI { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Major")]
        public int MajorId { get; set; }

        [ForeignKey("MajorId")]
        public virtual MajorRequirements Majors { get; set; }

        [Display(Name = "Student Plan")]
        public int StudentPlanId { get; set; }

        [ForeignKey("StudentPlanId")]
        public virtual StudentPlans Plan { get; set; }

        //public IEnumerable<MajorRequirements> Major { get; set; }

        //public ICollection<AcademicTerms> Terms { get; set; }
        
    }
}
