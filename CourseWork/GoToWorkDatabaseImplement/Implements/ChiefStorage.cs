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
    public class ChiefStorage : IChiefStorage
    {
        public List<ChiefViewModel> GetFullList()
        {
            using var context = new GoToWorkDatabase();
            return context.Chiefs
            .Select(CreateModel)
            .ToList();
        }
        public List<ChiefViewModel> GetFilteredList(ChiefBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            return context.Chiefs
            .Where(rec => rec.Login.Contains(model.Login))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public ChiefViewModel GetElement(ChiefBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GoToWorkDatabase();
            var Chief = context.Chiefs
            .FirstOrDefault(rec => rec.Login == model.Login ||
            rec.Id == model.Id);
            return Chief != null ? CreateModel(Chief) :
           null;
        }

        public void Insert(ChiefBindingModel model)
        {
            var context = new GoToWorkDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                Chief g = new Chief
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Login = model.Login
                };
                context.Chiefs.Add(g);
                context.SaveChanges();
                CreateModel(g);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(ChiefBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Chiefs.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(ChiefBindingModel model)
        {
            using var context = new GoToWorkDatabase();
            Chief element = context.Chiefs.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Chiefs.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static ChiefViewModel CreateModel(Chief Chief)
        {
            return new ChiefViewModel
            {
                Id = Chief.Id,
                FirstName = Chief.FirstName,
                LastName = Chief.LastName,
                Login = Chief.Login,
                Password = Chief.Password
            };
        }
    }
}
