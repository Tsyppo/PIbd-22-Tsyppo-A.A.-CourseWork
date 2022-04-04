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
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using var context = new GoToWorkDatabase();
            return context.Employees
            .Include(rec => rec.EmployeeMachines)
            .ThenInclude(rec => rec.Machine)
            .Select(CreateModel)
            .ToList();
        }
        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            return context.Employees
            .Include(rec => rec.EmployeeMachines)
            .ThenInclude(rec => rec.Machine)
            .Where(rec => rec.FirstName.Contains(model.FirstName))
            .Select(CreateModel)
            .ToList();
        }
        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            var Employee = context.Employees
            .FirstOrDefault(rec => rec.FirstName.Contains(model.FirstName)
            || rec.LastName.Contains(model.LastName) 
            || rec.Id == model.Id);
            return Employee != null ? CreateModel(Employee) : null;
        }
        public void Insert(EmployeeBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            context.Employees.Add(CreateModel(model, new Employee()));
            context.SaveChanges();
        }
        public void Update(EmployeeBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            var element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(EmployeeBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            Employee element = context.Employees.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Employees.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Employee CreateModel(EmployeeBindingModel model, Employee
       Employee)
        {
            Employee.FirstName = model.FirstName;
            Employee.LastName = model.LastName;
            return Employee;
        }
        private static EmployeeViewModel CreateModel(Employee Employee)
        {
            return new EmployeeViewModel
            {
                Id = Employee.Id,
                FirstName = Employee.FirstName,
                LastName = Employee.LastName,
                Experience = Employee.Experience
            };
        }
    }
}
