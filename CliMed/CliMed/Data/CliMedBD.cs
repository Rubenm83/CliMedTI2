using CliMed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Data
{
    public class CliMedBD: DbContext
    {

        public CliMedBD(DbContextOptions<CliMedBD> options) : base(options) { }

        public DbSet<Clinicas> Clinicas{ get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Utentes> Utentes { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Materiais> Materiais { get; set; }
    }
}
