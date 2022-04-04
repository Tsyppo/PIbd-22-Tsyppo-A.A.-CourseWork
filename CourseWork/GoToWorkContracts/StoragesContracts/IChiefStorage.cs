using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;

namespace GoToWorkContracts.StoragesContracts
{
    public interface IChiefStorage
    {
        List<ChiefViewModel> GetFullList();
        List<ChiefViewModel> GetFilteredList(ChiefBindingModel model);
        ChiefViewModel GetElement(ChiefBindingModel model);
        void Insert(ChiefBindingModel model);
        void Update(ChiefBindingModel model);
        void Delete(ChiefBindingModel model);
    }
}
