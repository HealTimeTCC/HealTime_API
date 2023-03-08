using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class PrescricaoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrescricaoPacientes",
                columns: table => new
                {
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Emissao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Validade = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DescFichaPessoa = table.Column<string>(type: "VARCHAR(350)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescricaoPacienteId", x => x.PrescricaoPacienteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescricaoPacientes");
        }
    }
}
