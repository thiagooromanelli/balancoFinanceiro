using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BalancoFinanceiro.Models
{
    public class BalancoDia
    {
        [Key]
        public DataType Date { get; set; }
        [Required]
        public double TotValCredit { get; set; }
        [Required]
        public double TotValDebit { get; set; }
        [Required]
        public double Balance { get; set; }
    }
}
