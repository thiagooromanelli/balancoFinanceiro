using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BalancoFinanceiro.Domain.Models
{
    public class BalancoFinanceiroContext : DbContext
    {
        public BalancoFinanceiroContext(DbContextOptions<BalancoFinanceiroContext> options):base(options)
        {
            
        }

        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}
