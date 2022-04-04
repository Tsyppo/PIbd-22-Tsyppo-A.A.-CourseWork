using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.StoragesContracts;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;
using GoToWorkContracts.Enums;
using GoToWorkDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GoToWorkDatabaseImplement.Implements
{
    public class MachineStorage : IMachineStorage
    {
        public List<MachineViewModel> GetFullList()
        {
            using var context = new GoToWorkDatabase();
            return context.Machines
            .Include(rec => rec.EmployeeMachines)
            .ThenInclude(rec => rec.Employee)
            .Select(CreateModel)
            .ToList();
        }
        public List<MachineViewModel> GetFilteredList(MachineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            return context.Machines
            .Include(rec => rec.EmployeeMachines)
            .ThenInclude(rec => rec.Employee)
            .Where(rec => rec.MachineType.Contains(model.MachineType))
            .Select(CreateModel)
            .ToList();
        }
        public MachineViewModel GetElement(MachineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            var Machine = context.Machines
            .FirstOrDefault(rec => rec.MachineType.Contains(model.MachineType)
            || rec.Id == model.Id);
            return Machine != null ? CreateModel(Machine) : null;
        }
        public void Insert(MachineBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            context.Machines.Add(CreateModel(model, new Machine()));
            context.SaveChanges();
        }
        public void Update(MachineBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            var element = context.Machines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(MachineBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            Machine element = context.Machines.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Machines.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Machine CreateModel(MachineBindingModel model, Machine
        Machine)
        {
            Machine.MachineType = model.MachineType;
            Machine.MachineStatus = model.MachineStatus;
            Machine.Count = model.Count;
            return Machine;
        }
        private static MachineViewModel CreateModel(Machine Machine)
        {
            return new MachineViewModel
            {
                Id = Machine.Id,
                MachineType = Machine.MachineType,
                MachineStatus = Machine.MachineStatus,
                Count = Machine.Count
            };
        }
    }
}
