﻿using Domain.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
