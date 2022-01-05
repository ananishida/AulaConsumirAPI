using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AulaConsumirAPicerto.Models
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome da pessoa: ")]
        [StringLength(100, MinimumLength = 5)]
        public string nome { get; set; }


    }

}
