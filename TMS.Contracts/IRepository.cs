using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TMS.Contracts
{
    public interface IRepository<T> where T :class
    {
        List<T> Get();
        List<T> Get(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        bool Exists(Expression<Func<T, bool>> predicate);
    }
}
