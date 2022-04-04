using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;

namespace GoToWorkContracts.BusinessLogicsContracts
{
    public interface IMachineLogic
    {
        List<MachineViewModel> Read(MachineBindingModel model);
        void CreateOrUpdate(MachineBindingModel model);
        void MachineInWork(ChangeStatusBindingModel model);
        void MachineIsFree(ChangeStatusBindingModel model);
    }
}
