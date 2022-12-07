using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee employee);
        Employee Update(int id, Employee employee);
        void Delete(int? id);
        Employee GetById(int? id);
        List<Employee> GetByAge(int? age);
        List<Employee> GetByDepartmentId(Department department);
        List<Employee> GetByDepartmentName(string name);
        List<Employee> Search(string searchText);
    }
}
