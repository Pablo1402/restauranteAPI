using Restaurante.ApplicationCore.Entity;
using Restaurante.ApplicationCore.Interfaces.Repository;
using Restaurante.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Restaurante.ApplicationCore.Services
{
    public class PratoService : IPratosService
    {
        private readonly IGenericRepository<prato> _dal;

        public PratoService(IGenericRepository<prato> dal)
        {
            _dal = dal;
        }

        public prato Add(prato entity)
        {
            return _dal.Add(entity);
        }

        public void Delete(prato entity)
        {
            _dal.Delete(entity);
        }

        public IEnumerable<prato> GetAll(params Expression<Func<prato, object>>[] navigationProperties)
        {
            return _dal.GetAll(navigationProperties);
        }

        public IEnumerable<prato> GetAllPratos(long restauranteId)
        {
            return _dal.GetList(x => x.restaurante_id == restauranteId);
        }

        public prato getById(long id, params Expression<Func<prato, object>>[] navigationProperties)
        {
            return _dal.getSingle(x => x.id == id);
        }

        public void Update(prato entity)
        {
            _dal.Update(entity);
        }
    }
}
