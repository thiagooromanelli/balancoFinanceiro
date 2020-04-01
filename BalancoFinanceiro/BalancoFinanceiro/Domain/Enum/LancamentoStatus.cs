using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancoFinanceiro.Domain.Enum
{
    public enum LancamentoStatus : int
    {
        Conciliado = 0,
        NaoConciliado = 1
    }
}
