using Restaurante.ApplicationCore.Entity;
using Restaurante.ApplicationCore.Interfaces.Repository;
using Restaurante.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Restaurante.ApplicationCore.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly IGenericRepository<restaurante> _dal;
        public RestauranteService(IGenericRepository<restaurante> dal)
        {
            _dal = dal;
        }

        public restaurante Add(restaurante entity)
        {
            return _dal.Add(entity);
        }

        public void Delete(restaurante entity)
        {
            _dal.Delete(entity);
        }

       
        public IEnumerable<restaurante> GetAll(params Expression<Func<restaurante, object>>[] navigationProperties)
        {
            return _dal.GetAll(navigationProperties);
        }


        public restaurante getById(long id, params Expression<Func<restaurante, object>>[] navigationProperties)
        {
            return _dal.getSingle(x => x.id == id, navigationProperties);
        }

        public IEnumerable<restaurante> GetByNome(string nome, params Expression<Func<restaurante, object>>[] navigationProperties)
        {
            if (string.IsNullOrEmpty(nome))
                return _dal.GetAll(navigationProperties);
            return _dal.GetList(x => x.nome.Contains(nome), navigationProperties);
        }

        public void Update(restaurante entity)
        {
            _dal.Update(entity);
        }
    }
}
