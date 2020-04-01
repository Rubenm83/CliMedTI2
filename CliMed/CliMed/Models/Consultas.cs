using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Consultas
    {
        [Key]
        public int IdClinica { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public DateTime DataMarcacao { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public bool EstConsulta { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(200)]
        public string Descricao { get; set; }

        [StringLength(200)]
        public string Receita { get; set; }

        // Chaves Estrangeiras
        [ForeignKey(nameof(Medico))]
        public int MedicoFK { get; set; }
        public Medicos Medico { get; set; }

        [ForeignKey(nameof(Utente))]
        public int UtenteFK { get; set; }
        public Utentes Utente { get; set; }

        [ForeignKey(nameof(Clinica))]
        public int ClinicaFK { get; set; }
        public Clinicas Clinica { get; set; }
    }
}
