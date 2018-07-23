using Restaurante.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Restaurante.ApplicationCore.Interfaces.Service
{
    public interface IRestauranteService
    {
        restaurante Add(restaurante entity);
        void Update(restaurante entity);
        void Delete(restaurante entity);
        restaurante getById(long id, params Expression<Func<restaurante, object>>[] navigationProperties);
        IEnumerable<restaurante> GetAll(params Expression<Func<restaurante, object>>[] navigationProperties);
        
    }
}
