using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class initialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    IdClinica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Morada = table.Column<string>(maxLength: 40, nullable: false),
                    Contacto = table.Column<string>(maxLength: 9, nullable: false),
                    Mail = table.Column<string>(maxLength: 30, nullable: false),
                    Foto = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    idMedico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nCedula = table.Column<string>(maxLength: 10, nullable: false),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    AnosExp = table.Column<short>(nullable: false),
                    Contacto = table.Column<string>(maxLength: 9, nullable: false),
                    Mail = table.Column<string>(maxLength: 30, nullable: false),
                    Morada = table.Column<string>(maxLength: 60, nullable: false),
                    CC = table.Column<string>(maxLength: 13, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.idMedico);
                });

            migrationBuilder.CreateTable(
                name: "Utentes",
                columns: table => new
                {
                    IdUtente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    Contacto = table.Column<string>(maxLength: 9, nullable: false),
                    Mail = table.Column<string>(maxLength: 30, nullable: false),
                    Morada = table.Column<string>(maxLength: 60, nullable: false),
                    CC = table.Column<string>(maxLength: 13, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utentes", x => x.IdUtente);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    Contacto = table.Column<string>(maxLength: 9, nullable: false),
                    Mail = table.Column<string>(maxLength: 30, nullable: false),
                    Morada = table.Column<string>(maxLength: 60, nullable: false),
                    CC = table.Column<string>(maxLength: 13, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: false),
                    ClinicaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Clinicas_ClinicaFK",
                        column: x => x.ClinicaFK,
                        principalTable: "Clinicas",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 30, nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    PrecoCompra = table.Column<float>(nullable: false),
                    precoVenda = table.Column<float>(nullable: false),
                    ClinicaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.IdMaterial);
                    table.ForeignKey(
                        name: "FK_Materiais_Clinicas_ClinicaFK",
                        column: x => x.ClinicaFK,
                        principalTable: "Clinicas",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IdClinica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataMarcacao = table.Column<DateTime>(nullable: false),
                    EstConsulta = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false),
                    Receita = table.Column<string>(maxLength: 200, nullable: true),
                    MedicoFK = table.Column<int>(nullable: false),
                    UtenteFK = table.Column<int>(nullable: false),
                    ClinicaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.IdClinica);
                    table.ForeignKey(
                        name: "FK_Consultas_Clinicas_ClinicaFK",
                        column: x => x.ClinicaFK,
                        principalTable: "Clinicas",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoFK",
                        column: x => x.MedicoFK,
                        principalTable: "Medicos",
                        principalColumn: "idMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Utentes_UtenteFK",
                        column: x => x.UtenteFK,
                        principalTable: "Utentes",
                        principalColumn: "IdUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ClinicaFK",
                table: "Consultas",
                column: "ClinicaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoFK",
                table: "Consultas",
                column: "MedicoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_UtenteFK",
                table: "Consultas",
                column: "UtenteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ClinicaFK",
                table: "Funcionarios",
                column: "ClinicaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_ClinicaFK",
                table: "Materiais",
                column: "ClinicaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Utentes");

            migrationBuilder.DropTable(
                name: "Clinicas");
        }
    }
}
