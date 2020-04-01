using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    /// <summary>
    /// Representa a tabela 'Clinica' na Base de Dados
    /// </summary>
    public class Clinicas
    {
        //inicializar lista de materiais
        public Clinicas()
        {
            ListaDeMateriais = new HashSet<Materiais>();
        }

        [Key] 
        public int IdClinica { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(40)]
        public string Morada { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        public string Contacto { get; set; }

        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(30, ErrorMessage ="O {0} deve ter no máximo {1} caracteres.")]
        public string Mail { get; set; }

        [StringLength(15,ErrorMessage ="A {0} não deverá ter mais de {1} caracteres.")]
        public string Foto { get; set; }

        // lista de 'materiais' da clinica
        public ICollection<Materiais> ListaDeMateriais { get; set; }

    }
}
