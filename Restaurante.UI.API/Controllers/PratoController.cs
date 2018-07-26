using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.ApplicationCore.Entity;
using Restaurante.ApplicationCore.Interfaces.Service;
using Restaurante.ApplicationCore.Services;

namespace Restaurante.UI.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Prato")]
    public class PratoController : Controller
    {

        private readonly IPratosService _svc;
        public PratoController(IPratosService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public IEnumerable<prato> Get()
        {
            var data = _svc.GetAll(x => x.restaurante);
            return data;
        }

        [HttpGet("nome/{nome}")]
        public IEnumerable<prato> GetByNome(string nome)
        {
            var data = _svc.GetByNome(nome, x => x.restaurante);
            return data;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var prato = _svc.getById(id);
                if (prato == null)
                    return NotFound("Prato não encontrado");
                return Ok(prato);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Save([FromBody]prato prato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _svc.Add(prato);
                    return new CreatedAtRouteResult("prato salvo com sucesso!", new { id = prato.id, url = "api/prato/" + prato.id });
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody]prato prato, int id)
        {
            try
            {
                if (prato.id != id)
                    return BadRequest();
                _svc.Update(prato);
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
                var prato = _svc.getById(id);
                if (prato == null)
                    return NotFound();
                _svc.Delete(prato);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}