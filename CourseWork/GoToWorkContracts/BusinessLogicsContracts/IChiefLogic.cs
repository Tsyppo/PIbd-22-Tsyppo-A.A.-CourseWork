using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;

namespace GoToWorkContracts.BusinessLogicsContracts
{
    public interface IChiefLogic
    {
        List<ChiefViewModel> Read(ChiefBindingModel model);
        void CreateOrUpdate(ChiefBindingModel model);
        void Delete(ChiefBindingModel model);
        bool Login(ChiefBindingModel model);
    }
}
