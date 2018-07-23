using Restaurante.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Restaurante.ApplicationCore.Interfaces.Service
{
    public interface IPratosService
    {
        prato Add(prato entity);
        void Update(prato entity);
        void Delete(prato entity);
        prato getById(long id,  params Expression<Func<prato, object>>[] navigationProperties);
        IEnumerable<prato> GetAll(params Expression<Func<prato, object>>[] navigationProperties);
        IEnumerable<prato> GetAllPratos(long restauranteId);
    }
}
