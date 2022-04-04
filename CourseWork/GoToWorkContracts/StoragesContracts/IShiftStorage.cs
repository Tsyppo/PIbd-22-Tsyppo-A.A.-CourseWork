using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;

namespace GoToWorkContracts.StoragesContracts
{
    public interface IShiftStorage
    {
        List<ShiftViewModel> GetFullList();
        List<ShiftViewModel> GetFilteredList(ShiftBindingModel model);
        ShiftViewModel GetElement(ShiftBindingModel model);
        void Insert(ShiftBindingModel model);
        void Update(ShiftBindingModel model);
        void Delete(ShiftBindingModel model);
    }
}
