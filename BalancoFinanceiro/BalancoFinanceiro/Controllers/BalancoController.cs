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
    public class BalancoController : ControllerBase
    {
        private readonly BalancoFinanceiroContext _context;
        

        public BalancoController(BalancoFinanceiroContext context)
        {
            _context = context;
        }

        // GET: api/Balanco/BalancoDiario/{date}
        [HttpGet("BalancoDiario/{date}")]
        public async Task<ActionResult<List<BalancoDiario>>> BalancoDiario([FromRoute]string date)
        {
            //var dateWithoutTime = date.Split(' ')[0];
            var dateWithoutTime = System.Uri.UnescapeDataString(date.Split(' ')[0]);
            var sqlQuery = "SELECT * FROM Lancamentos WHERE date LIKE '%" + dateWithoutTime + "%'";

            var queryResult = await _context.Lancamentos.FromSqlRaw(sqlQuery).ToListAsync();
            bool isEmpty = !queryResult.Any();
            if (isEmpty)
            {
                return NotFound();
            }
            else
            {
                return GerarBalancoDiario(queryResult);
            }
        }

        // GET: api/Balanco/BalancoMensal/{month}
        [HttpGet("BalancoMensal/{month}")]
        public async Task<ActionResult<Tuple<List<BalancoDiario>,double>>> BalancoMensal([FromRoute]string month)
        {
            var sqlQuery = "SELECT * FROM Lancamentos WHERE date LIKE '" + month + "%'";

            var queryResult = await _context.Lancamentos.FromSqlRaw(sqlQuery).ToListAsync();
            bool isEmpty = !queryResult.Any();
            if (isEmpty)
            {
                return NotFound();
            }
            else
            {
                return GerarBalancoMensal(queryResult);
            }
        }

        private List<BalancoDiario> GerarListaBalancos(List<Lancamento> queryResult)
        {
            var balancoDiario = new List<BalancoDiario>();
            
            foreach (var lancamento in queryResult)
            {
                var balanco = new BalancoDiario();
                if (lancamento.type == (int)LancamentoTipo.Credito)
                {
                    balanco.totValCredit += lancamento.value;
                    balanco.balance += lancamento.value;
                }
                else if (lancamento.type == (int)LancamentoTipo.Debito)
                {
                    balanco.totValDebit += lancamento.value;
                    balanco.balance -= lancamento.value;
                }
                balanco.date = lancamento.date;
                balancoDiario.Add(balanco);
            }
            return balancoDiario;
        }

        private List<BalancoDiario> GerarBalancoDiario(List<Lancamento> queryResult)
        {
            var balancos = GerarListaBalancos(queryResult);
            var balancoDiario = balancos.GroupBy(balanco => balanco.date.Split(' ')[0])
                .Select(balancoGroup => new BalancoDiario()
                {
                    date = balancoGroup.First().date.Split(' ')[0],
                    totValCredit = balancoGroup.Sum(sum => sum.totValCredit),
                    totValDebit = balancoGroup.Sum(sum => sum.totValDebit),
                    balance = balancoGroup.Sum(sum => sum.totValCredit) - balancoGroup.Sum(sum => sum.totValDebit),
                }).ToList();

            return balancoDiario;
        }

        private Tuple<List<BalancoDiario>, double> GerarBalancoMensal(List<Lancamento> queryResult)
        {
            var balancos = GerarListaBalancos(queryResult);
            var balancoMensal =  balancos.GroupBy(balanco => balanco.date.Split(' ')[0])
                .Select(balancoGroup => new BalancoDiario()
                {
                    date = balancoGroup.First().date.Split(' ')[0],
                    totValCredit = balancoGroup.Sum(sum => sum.totValCredit),
                    totValDebit = balancoGroup.Sum(sum => sum.totValDebit),
                    balance = balancoGroup.Sum(sum => sum.totValCredit) - balancoGroup.Sum(sum => sum.totValDebit),
                }).ToList();

            double saldoMensal = 0;

            foreach (var balanco in balancoMensal)
            {
                saldoMensal += balanco.balance;
            }

            return new Tuple<List<BalancoDiario>, double>(balancoMensal, saldoMensal);
        }
    }
}
