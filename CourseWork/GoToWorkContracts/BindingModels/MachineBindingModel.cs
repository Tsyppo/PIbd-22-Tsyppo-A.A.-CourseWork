using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.Enums;

namespace GoToWorkContracts.BindingModels
{
    public class MachineBindingModel
    {
        public int? Id { get; set; }
        public string MachineType { get; set; }
        public MachineStatus MachineStatus { get; set; }
        public int Count { get; set; }
    }
}
