using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Utentes
    {
        [Key]
        public int IdUtente { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(60)]
        public string Morada { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(13)]
        public string CC { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        public string NIF { get; set; }

    }
}
