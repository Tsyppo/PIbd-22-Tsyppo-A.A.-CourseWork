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
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeStorage _employeeStorage;
        public EmployeeLogic(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }
        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return _employeeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { _employeeStorage.GetElement(model) };
            }
            return _employeeStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var element = _employeeStorage.GetElement(new EmployeeBindingModel
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
                _employeeStorage.Update(model);
            }
            else
            {
                _employeeStorage.Insert(model);
            }
        }
        public void Delete(EmployeeBindingModel model)
        {
            var element = _employeeStorage.GetElement(new EmployeeBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Работник не найден");
            }
            _employeeStorage.Delete(model);
        }
    }
}
