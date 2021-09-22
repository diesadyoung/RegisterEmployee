using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterEmployee.Models
{
    public class Employees
    {
        
        public int Id { get; set; }

        
        public string Surname { get; set; }

        
        public string Name { get; set; }

        
        public string Patronymic { get; set; }

        
        public DateTime Date { get; set; }

        
        public string CompanyName { get; set; }
    }
}
