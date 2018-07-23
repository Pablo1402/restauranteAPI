using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Restaurante.ApplicationCore.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class 
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T getSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IEnumerable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}
