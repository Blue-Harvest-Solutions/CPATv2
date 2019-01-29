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
        public string N_Number { get; set; }

        [Required]
        public string FirstName { get; set; }

        public char MI { get; set; }

        [Required]
        public string LastName { get; set; }

        
    }
}
