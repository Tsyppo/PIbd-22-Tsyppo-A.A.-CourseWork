using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoToWorkDatabaseImplement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Experience { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Chief Cheif { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual List<EmployeeMachine> EmployeeMachines { get; set; }
    }
}
