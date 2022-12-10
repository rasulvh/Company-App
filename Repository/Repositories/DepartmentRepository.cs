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
            Department department = Get(m=> m.Id == entity.Id);

            if(entity is null) throw new ArgumentNullException();
            if(department is null) throw new ArgumentNullException();

            department.Name = entity.Name;
            department.Capacity = entity.Capacity;
        }
    }
}