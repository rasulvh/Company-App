using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IDepartmentService
    {
        Department Create(Department library);
        Department Update(int id, Department library);
        void Delete(int? id);
        Department GetById(int? id);
        Department GetByName(string name);
        List<Department> GetAll();
        List<Department> Search(string searchText);
    }
}
