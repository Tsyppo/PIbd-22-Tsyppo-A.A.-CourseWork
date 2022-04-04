using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoToWorkDatabaseImplement.Models
{
    public class Machine
    {
        public int Id { get; set; }
        [Required]
        public string MachineType { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public MachineStatus MachineStatus { get; set; }
        public virtual Chief Cheif { get; set; }
        [ForeignKey("MachineId")]
        public virtual List<EmployeeMachine> EmployeeMachines { get; set; }
    }
}
