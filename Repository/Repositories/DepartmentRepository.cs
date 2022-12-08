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
    public class DepartmentRepository : IRepository<Department>
    {
        Department department = new Department();

        public void Add(Department entity)
        {
            if (entity is null) throw new ArgumentNullException();
            AppDbContext<Department>.datas.Add(entity);
        }

        public void Delete(Department entity)
        {
            if(entity is null) throw new ArgumentNullException();
            AppDbContext<Department>.datas.Remove(entity);
        }

        public Department Get(Predicate<Department> predicate)
        {
            return AppDbContext<Department>.datas.Find(predicate);
        }

        public List<Department> GetAll(Predicate<Department> predicate)
        {
            return predicate == null ? AppDbContext<Department>.datas : AppDbContext<Department>.datas.FindAll(predicate);
        }

        public void Update(Department entity)
        {
            if(entity is null) throw new ArgumentNullException();

            //entity.Name = department.Name;
            //entity.Capacity = department.Capacity;
        }
    }
}