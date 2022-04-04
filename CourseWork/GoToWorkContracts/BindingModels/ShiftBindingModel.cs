using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToWorkContracts.BindingModels
{
    public class ShiftBindingModel
    {
        public int? Id { get; set; }
        public string TypeOfshift { get; set; }
        public string WorkDays { get; set; }
    }
}