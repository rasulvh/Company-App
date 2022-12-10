using Domain.Models;
using Repository.Data;
using Repository.Helpers.Exceptions;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repo;
        private int _count;

        public EmployeeService()
        {
            _repo = new EmployeeRepository();
        }

        public int Count()
        {
            return _repo.GetAll(null).Count;
        }

        public Employee Create(Employee employee)
        {
            employee.Id = _count;
            _repo.Add(employee);
            _count++;
            return employee;
        }

        public void Delete(int? id)
        {
            if(id is null) throw new ArgumentNullException();

            Employee employee = GetById(id);

            if(employee is null) throw new NotFoundException("Employee not found");

            _repo.Delete(employee);
        }

        public List<Employee> GetByAge(int? age)
        {
            if(age is null) throw new ArgumentNullException();

            return _repo.GetAll(m => m.Age == age);
        }

        public List<Employee> GetByDepartmentId(int? id)
        {
            if(id is null) throw new ArgumentNullException();

            return _repo.GetAll(m => m.Id == id);
        }

        public List<Employee> GetByDepartmentName(string name)
        {
            if (name is null) throw new ArgumentNullException();

            return _repo.GetAll(m=> m.Department.Name.Contains(name));
        }

        public Employee GetById(int? id)
        {
            if(id is null) throw new ArgumentNullException();

            return _repo.Get(m => m.Id == id);
        }

        public List<Employee> Search(string searchText)
        {
            if (searchText is null) return _repo.GetAll(null);

            return _repo.GetAll(m=> m.Name.ToLower().Contains(searchText.ToLower()) || m.Surname.ToLower().Contains(searchText.ToLower()));
        }

        public Employee Update(int id, Employee employee)
        {
            employee.Id = id;
            _repo.Update(employee);
            return employee;
        }
    }
}