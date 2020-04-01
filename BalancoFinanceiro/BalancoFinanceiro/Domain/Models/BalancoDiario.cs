using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BalancoFinanceiro.Domain.Models
{
    public class BalancoDiario
    {
        [Key]
        public string date { get; set; }
        [Required]
        public double totValCredit { get; set; }
        [Required]
        public double totValDebit { get; set; }
        [Required]
        public double balance { get; set; }
    }
}

