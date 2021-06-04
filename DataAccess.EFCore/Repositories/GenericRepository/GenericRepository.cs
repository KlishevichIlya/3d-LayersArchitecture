using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class                                                                  
    {
        protected readonly ApplicationContext Context;

        public GenericRepository(ApplicationContext context)
        {
            Context = context;
        }

        public T GetById(int id) => Context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => Context.Set<T>().ToList();

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression) => Context.Set<T>().Where(expression);

        public void Add(T entity) => Context.Set<T>().Add(entity);

        public void AddRange(IEnumerable<T> entities) => Context.Set<T>().AddRange(entities);

        public void Remove(T entity) => Context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => Context.Set<T>().RemoveRange(entities);
    }
}