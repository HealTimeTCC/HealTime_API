using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class CuidadorPacienteIncluindoDataResponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "CuidadorPacientes",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdResponsavelPessoaId",
                table: "CuidadorPacientes",
                type: "varchar(40)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsavelId",
                table: "CuidadorPacientes",
                type: "varchar(40)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_IdResponsavelPessoaId",
                table: "CuidadorPacientes",
                column: "IdResponsavelPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_IdResponsavelPessoaId",
                table: "CuidadorPacientes",
                column: "IdResponsavelPessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_IdResponsavelPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropIndex(
                name: "IX_CuidadorPacientes_IdResponsavelPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "IdResponsavelPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "CuidadorPacientes");
        }
    }
}
