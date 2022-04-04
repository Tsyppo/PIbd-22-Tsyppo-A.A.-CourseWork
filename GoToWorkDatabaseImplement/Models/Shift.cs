using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoToWorkDatabaseImplement.Models
{
    public class Shift
    {
        public int Id { get; set; }
        [Required]
        public string TypeOfshift { get; set; }
        [Required]
        public string WorkDays { get; set; }
        public virtual Chief Cheif { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
