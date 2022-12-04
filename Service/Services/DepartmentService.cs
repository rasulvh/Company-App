﻿using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Department GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Department> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Department Update(int id, Department library)
        {
            throw new NotImplementedException();
        }
    }
}