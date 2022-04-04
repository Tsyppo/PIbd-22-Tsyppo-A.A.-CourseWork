using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GoToWorkContracts.ViewModels
{
    public class ShiftViewModel
    {
        public int Id { get; set; }
        [DisplayName("Вид смены")]
        public string TypeOfshift { get; set; }
        [DisplayName("Рабочие дни")]
        public string WorkDays { get; set; }
    }
}
