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

        public List<Employee> GetByDepartmentId(Department department)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByDepartmentName(Department department)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int? id)
        {
            if(id is null) throw new ArgumentNullException();

            return _repo.Get(m => m.Id == id);
        }

        public List<Employee> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}