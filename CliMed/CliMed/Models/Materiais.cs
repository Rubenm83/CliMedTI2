using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Materiais
    {
        [Key]
        public int IdMaterial { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public int Stock { get; set; }

        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public float PrecoCompra { get; set; }

        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório")]
        public float precoVenda { get; set; }


        //chave estrangeiras
        [ForeignKey(nameof(Clinica))]
        public int ClinicaFK { get; set; }
        public Clinicas Clinica { get; set; }

    }
}
