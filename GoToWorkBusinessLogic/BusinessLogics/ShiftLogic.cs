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
    public class ShiftLogic : IShiftLogic
    {
        private readonly IShiftStorage _shiftStorage;
        public ShiftLogic(IShiftStorage shiftStorage)
        {
            _shiftStorage = shiftStorage;
        }
        public List<ShiftViewModel> Read(ShiftBindingModel model)
        {
            if (model == null)
            {
                return _shiftStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ShiftViewModel> { _shiftStorage.GetElement(model) };
            }
            return _shiftStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ShiftBindingModel model)
        {
            var element = _shiftStorage.GetElement(new ShiftBindingModel
            {
                TypeOfshift = model.TypeOfshift,
                WorkDays = model.WorkDays
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть подобная смена");
            }
            if (model.Id.HasValue)
            {
                _shiftStorage.Update(model);
            }
            else
            {
                _shiftStorage.Insert(model);
            }
        }
        public void Delete(ShiftBindingModel model)
        {
            var element = _shiftStorage.GetElement(new ShiftBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Смена не найдена");
            }
            _shiftStorage.Delete(model);
        }
    }
}
