using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BalancoFinanceiro.Models
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
        public string type { get; set; }
        [Required]
        public string status { get; set; }
    }
}
