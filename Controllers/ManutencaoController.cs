using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Operacao.Context;
using Manutencao.Entities;

namespace Manutencao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManutencaoController : ControllerBase
    {
        private readonly OperacaoContext _context;

        public ManutencaoController(OperacaoContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var reparo = _context.Reparos.Find(id);

            if (reparo == null)
                return NotFound();

            return Ok(reparo);
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodosAsync(int? pagina)
        {
            int TamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            int pular = (numeroPagina - 1) * TamanhoPagina;

            List<Reparo> reparos = await _context.Reparos.Skip(pular)
                                                         .Take(TamanhoPagina)
                                                         .ToListAsync();
            return Ok(reparos);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatus status)
        {
            var reparo = _context.Reparos.Where(x => x.Status == status);
            return Ok(reparo);
        }

        [HttpPost]
        public IActionResult Maquina(Reparo reparo)
        {
            _context.Add(reparo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = reparo.Id }, reparo);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Reparo reparo)
        {
            var reparoBanco = _context.Reparos.Find(id);

            if (reparoBanco == null)
                return NotFound();

            reparoBanco.Maquina = reparo.Maquina;
            reparoBanco.Local = reparo.Local;
            reparoBanco.Problema = reparo.Problema;
            reparoBanco.Status = reparo.Status;

            _context.SaveChanges();
            return Ok();
        }

        
        /*ESSA PARTE PRECISA IMPLANTAR O JWT PARA ATUALIZAR
        ELA SERVIRÁ PARA APENAS O ADM, VULGO MECANICO, ATUALIZAR O STATUS DO REPARO DA MAQUIA*/
        [HttpPut("status")]
        public IActionResult AtualizarStatus(int id, Reparo reparo)
        {
            var reparoBanco = _context.Reparos.Find(id);

            if (reparoBanco == null)
                return NotFound();

            reparoBanco.Status = reparo.Status;

            _context.SaveChanges();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var reparoBanco = _context.Reparos.Find(id);

            if (reparoBanco == null)
                return NotFound();

            _context.Reparos.Remove(reparoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}