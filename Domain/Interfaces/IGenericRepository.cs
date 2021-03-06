using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T,U> where T : class 
                                             where U : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(U entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}