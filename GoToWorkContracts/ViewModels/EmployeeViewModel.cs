using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GoToWorkContracts.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Стаж")]
        public int Experience { get; set; }
    }
}
