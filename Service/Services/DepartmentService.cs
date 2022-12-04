using Domain.Models;
using Microsoft.VisualBasic;
using Repository.Helpers.Exceptions;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository _repo;
        private int _count;

        public DepartmentService()
        {
            _repo = new DepartmentRepository();
        }

        public Department Create(Department department)
        {
            department.Id = _count;
            _repo.Add(department);
            _count++;
            return department;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            Department department = GetById(id);

            if (department == null) throw new NotFoundException("Department not found");

            _repo.Delete(department);
        }

        public List<Department> GetAll()
        {
            return _repo.GetAll(null);
        }

        public Department GetById(int? id)
        {
            if(id is null) throw new ArgumentNullException();
            return _repo.Get(m=> m.Id == id);
        }

        public Department GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Department> Search(string searchText)
        {
            return _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()));
        }

        public Department Update(int id, Department library)
        {
            throw new NotImplementedException();
        }
    }
}
