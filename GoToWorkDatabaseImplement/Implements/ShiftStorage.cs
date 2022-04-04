using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.StoragesContracts;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;
using GoToWorkDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GoToWorkDatabaseImplement.Implements
{
    public class ShiftStorage : IShiftStorage
    {
        public List<ShiftViewModel> GetFullList()
        {
            using var context = new GoToWorkDatabase();
            return context.Shifts
            .Select(CreateModel)
            .ToList();
        }
        public List<ShiftViewModel> GetFilteredList(ShiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            return context.Shifts
            .Where(rec => rec.TypeOfshift.Contains(model.TypeOfshift))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public ShiftViewModel GetElement(ShiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            var Shift = context.Shifts
            .FirstOrDefault(rec => rec.TypeOfshift == model.TypeOfshift ||
            rec.Id == model.Id);
            return Shift != null ? CreateModel(Shift) :
           null;
        }

        public void Insert(ShiftBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            context.Shifts.Add(CreateModel(model, new Shift()));
            context.SaveChanges();
        }
        public void Update(ShiftBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            var element = context.Shifts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ShiftBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            Shift element = context.Shifts.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Shifts.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Shift CreateModel(ShiftBindingModel model, Shift
       Shift)
        {
            Shift.TypeOfshift = model.TypeOfshift;
            Shift.WorkDays = model.WorkDays;
            return Shift;
        }
        private static ShiftViewModel CreateModel(Shift Shift)
        {
            return new ShiftViewModel
            {
                Id = Shift.Id,
                TypeOfshift = Shift.TypeOfshift,
                WorkDays = Shift.WorkDays,
            };
        }
    }
}
