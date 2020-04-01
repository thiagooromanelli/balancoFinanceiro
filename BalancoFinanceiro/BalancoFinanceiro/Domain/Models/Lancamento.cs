using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BalancoFinanceiro.Domain.Enum;

namespace BalancoFinanceiro.Domain.Models
{
    public class Lancamento
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public double value { get; set; }
        [Required]
        [EnumDataType(typeof(LancamentoTipo))]
        public int type { get; set; }
        [Required]
        [EnumDataType(typeof(LancamentoStatus))]
        public int status { get; set; }
    }
}
