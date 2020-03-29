using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BalancoFinanceiro.Models
{
    public class LancamentoContext : DbContext
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> options):base(options)
        {
            
        }

        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}
