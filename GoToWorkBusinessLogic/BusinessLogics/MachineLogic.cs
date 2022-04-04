using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.BusinessLogicsContracts;
using GoToWorkContracts.Enums;
using GoToWorkContracts.StoragesContracts;
using GoToWorkContracts.ViewModels;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    public class MachineLogic : IMachineLogic
    {

        private readonly IMachineStorage _machineStorage;

        public MachineLogic(IMachineStorage machineStorage)
        {
            _machineStorage = machineStorage;
        }

        public List<MachineViewModel> Read(MachineBindingModel model)
        {
            if (model == null)
            {
                return _machineStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<MachineViewModel> { _machineStorage.GetElement(model) };
            }
            return _machineStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(MachineBindingModel model)
        {
            var element = _machineStorage.GetElement(new MachineBindingModel
            {
                MachineType = model.MachineType,
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть станок такого типа");
            }
            if (model.Id.HasValue)
            {
                _machineStorage.Update(model);
            }
            else
            {
                _machineStorage.Insert(model);
            }
        }

        public void MachineInWork(ChangeStatusBindingModel model)
        {
            var Machine = _machineStorage.GetElement(new MachineBindingModel
            {
                Id = model.MachineId
            });
            if (Machine == null)
            {
                throw new Exception("Не найден станок");
            }
            if (Machine.MachineStatus != (MachineStatus.Свободен))
            {
                throw new Exception("Заказ не в статусе \"Свободен\"");
            }
            _machineStorage.Update(new MachineBindingModel
            {
                Id = Machine.Id,
                MachineType = Machine.MachineType,
                Count = Machine.Count,
                MachineStatus = MachineStatus.Занят
            });
        }

        public void MachineIsFree(ChangeStatusBindingModel model)
        {
            var Machine = _machineStorage.GetElement(new MachineBindingModel
            {
                Id = model.MachineId
            });
            if (Machine == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (Machine.MachineStatus != (MachineStatus.Занят))
            {
                throw new Exception("Заказ не в статусе \"Занят\"");
            }
            _machineStorage.Update(new MachineBindingModel
            {
                Id = Machine.Id,
                Count = Machine.Count,
                MachineType = Machine.MachineType,
                MachineStatus = MachineStatus.Свободен
            });
        }
    }
}
