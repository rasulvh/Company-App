using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Add(Employee entity)
        {
            if (entity is null) throw new ArgumentNullException();
            AppDbContext<Employee>.datas.Add(entity);
        }
        public void Delete(Employee entity)
        {
            if(entity is null) throw new ArgumentNullException();
            AppDbContext<Employee>.datas.Remove(entity);
        }
        public Employee Get(Predicate<Employee> predicate) 
        {
            return AppDbContext<Employee>.datas.Find(predicate);
        }
        public List<Employee> GetAll(Predicate<Employee> predicate)
        {
            return predicate == null ? AppDbContext<Employee>.datas : AppDbContext<Employee>.datas.FindAll(predicate);
        }

        public void Update(Employee entity)
        {
            Employee employee = Get(m => m.Id == entity.Id);

            if(entity is null) throw new ArgumentNullException();
            if (employee is null) throw new ArgumentNullException();

            if (!string.IsNullOrEmpty(entity.Name))
            {
                employee.Name = entity.Name;
            }
            if (!string.IsNullOrEmpty(entity.Surname))
            {
                employee.Surname = entity.Surname;
            }
            if (!string.IsNullOrEmpty(entity.Address))
            {
                employee.Address = entity.Address;
            }
            if (entity.Age > 18 || entity.Age < 70)
            {
                employee.Age = entity.Age;
            }
            if (entity.Department != null)
            {
                employee.Department = entity.Department;
            }
        }
    }
}