using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.ApplicationCore.Entity;
using Restaurante.ApplicationCore.Interfaces.Service;

namespace Restaurante.UI.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurante")]
    public class RestauranteController : Controller
    {

        private readonly IRestauranteService _svc;
        public RestauranteController(IRestauranteService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public IEnumerable<restaurante> Get()
        {
            var data = _svc.GetAll(x => x.pratos);
            return data;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var prato = _svc.getById(id, x => x.pratos);
                if (prato == null)
                    return NotFound("Restaurante não encontrado");
                return Ok(prato);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Save([FromBody]restaurante restaurante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _svc.Add(restaurante);
                    return new CreatedAtRouteResult("Restaurante salvo com sucesso!", new { id = restaurante.id, url = "api/restaurante/" + restaurante.id });
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody]restaurante restaurante, int id)
        {
            try
            {
                if (restaurante.id != id)
                    return BadRequest();
                _svc.Update(restaurante);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var restaurante = _svc.getById(id);
                if (restaurante == null)
                    return NotFound();
                _svc.Delete(restaurante);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}