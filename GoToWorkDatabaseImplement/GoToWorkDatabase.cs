using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GoToWorkDatabaseImplement
{
    public class GoToWorkDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AbstractBarDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Chief> Chiefs { set; get; }
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<Machine> Machines { set; get; }
        public virtual DbSet<Shift> Shifts{ set; get; }
        public virtual DbSet<EmployeeMachine> EmployeeMachines { set; get; }
    }
}
