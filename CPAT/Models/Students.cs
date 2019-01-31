using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        
    }
}
