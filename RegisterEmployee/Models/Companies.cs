using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterEmployee.Models
{
    public class Companies
    {
        [Key]
        public int Id { get; set; }

        public string CompanyName { get; set; }
        
        // Opf - организационно-правовая форма
        public string Opf { get; set; }
    }
}
