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
        public int Id { get; set; }
        [Required]
        public DataType Date { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
