using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoToWorkDatabaseImplement.Models
{
    public class Chief
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        public int Password { get; set; }
        [ForeignKey("CheifId")]
        public virtual List<Employee> Employees { get; set; }
        [ForeignKey("CheifId")]
        public virtual List<Shift> Shifts { get; set; }
        [ForeignKey("CheifId")]
        public virtual List<Machine> Machines { get; set; }
    }
}
