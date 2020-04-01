using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancoFinanceiro.Domain.Enum;
using BalancoFinanceiro.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BalancoFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly BalancoFinanceiroContext _context;

        public LancamentosController(BalancoFinanceiroContext context)
        {
            _context = context;
        }

        // GET: api/Lancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lancamento>>> GetLancamentos()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        // GET: api/Lancamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lancamento>> GetLancamento(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);

            if (lancamento == null)
            {
                return NotFound();
            }

            return lancamento;
        }

        // PUT: api/Lancamentos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLancamento(int id, Lancamento lancamento)
        {
            if (id != lancamento.id)
            {
                return BadRequest();
            }

            if (LancamentoConciliado(id))
            {
                return BadRequest();
            }

            _context.Entry(lancamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Lancamentos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Lancamento>> PostLancamento(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLancamento", new { id = lancamento.id }, lancamento);
        }

        // DELETE: api/Lancamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lancamento>> DeleteLancamento(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }

            if (LancamentoConciliado(id))
            {
                return BadRequest();
            }

            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();

            return lancamento;
        }

        private bool LancamentoExists(int id)
        {
            return _context.Lancamentos.Any(e => e.id == id);
        }

        private bool LancamentoConciliado(int id)
        {
            return _context.Lancamentos.Any(e => e.id == id && e.status == (int)LancamentoStatus.Conciliado);
        }
    }
}
