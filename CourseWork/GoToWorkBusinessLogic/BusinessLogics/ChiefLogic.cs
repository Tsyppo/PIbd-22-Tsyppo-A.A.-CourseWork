using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.BusinessLogicsContracts;
using GoToWorkContracts.StoragesContracts;
using GoToWorkContracts.ViewModels;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    public class ChiefLogic : IChiefLogic
    {
        private readonly IChiefStorage _chiefStorage;
        public ChiefLogic(IChiefStorage chiefStorage)
        {
            _chiefStorage = chiefStorage;
        }
        public List<ChiefViewModel> Read(ChiefBindingModel model)
        {
            if (model == null)
            {
                return _chiefStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ChiefViewModel> { _chiefStorage.GetElement(model) };
            }
            return _chiefStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ChiefBindingModel model)
        {
            var element = _chiefStorage.GetElement(new ChiefBindingModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть работник с таким именем и фаилией");
            }
            if (model.Id.HasValue)
            {
                _chiefStorage.Update(model);
            }
            else
            {
                _chiefStorage.Insert(model);
            }
        }
        public void Delete(ChiefBindingModel model)
        {
            var element = _chiefStorage.GetElement(new ChiefBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Работник не найден");
            }
            _chiefStorage.Delete(model);
        }

        public bool Login(ChiefBindingModel model)
        {
            var provider = _chiefStorage.GetElement(new ChiefBindingModel
            {
                Login = model.Login,
                Password = model.Password
            });
            if (provider == null)
            {
                throw new Exception("Начальник c такими данными не найден");
            }
            if (provider != null && !provider.Password.Equals(model.Password)) 
            {
                throw new Exception("Неверный пароль");
            }
            return true;
        }
    }
}
