using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoToWorkDatabaseImplement.Models
{
    public class EmployeeMachine
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int MachineId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
