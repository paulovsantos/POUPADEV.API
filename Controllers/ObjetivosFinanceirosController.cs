using Microsoft.AspNetCore.Mvc;
using POUPADEV.API.Controllers.Models;
using PoupaDev.API.Entities;
using POUPADEV.API.Enums;
using POUPADEV.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace POUPADEV.API.Controllers
{
    [ApiController]
    [Route("api/objetivos-financeiros")]
    public class ObjetivosFinanceirosController : ControllerBase
    {
        private readonly PoupaDevContext _context;
        public ObjetivosFinanceirosController(PoupaDevContext context)
        {
            _context = context;
        }
        // GET api/objetivos-financeiros
        [HttpGet]
        public IActionResult GetTodos() {
            var objetivo = _context.Objetivos;

            return Ok(objetivo);
        }

        //GET api/objetivos-finceiros/1
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id) {
            var objetivo = _context
            .Objetivos
            .Include(o => o.Operacoes)
            .SingleOrDefault(o => o.Id == id);

            if(objetivo == null) 
                return NotFound();
            
            
            return Ok(objetivo);
        }

        //POST pai/objetivos-financeiros
        [HttpPost]
        public IActionResult Post(ObjetivoFinanceiroInputModel model) {
            var objetivo = new ObjetivoFinanceiro(
                model.Titulo, model.Descricao, model.ValorObjetivo);

                _context.Objetivos.Add(objetivo);
                _context.SaveChanges();

                var id = objetivo.Id;

            return CreatedAtAction(
                    "GetPorId",
                    new { id= id},
                    model
            );
        }

        // POST api/objetivos-financeiros/1/operacoes
        [HttpPost("{id}/operacoes")] 
        public IActionResult PostOperacao(int id, OperacaoInputModel model) {
            var operacao = new Operacao(model.Valor, model.TipoOperacao, id);

            var objetivo = _context
            .Objetivos
            .Include(o => o.Operacoes)
            .SingleOrDefault(o => o.Id == id);

            if(objetivo == null) 
                return NotFound();

            objetivo.RealizarOperacao(operacao);

            _context.SaveChanges();

            return NoContent();
            
            
        }
        }
}
