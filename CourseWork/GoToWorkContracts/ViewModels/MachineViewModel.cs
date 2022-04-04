using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GoToWorkContracts.Enums;

namespace GoToWorkContracts.ViewModels
{
    public class MachineViewModel
    {
        public int Id { get; set; }
        [DisplayName("Вид станка")]
        public string MachineType { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Статус")]
        public MachineStatus MachineStatus { get; set; }
    }
}
