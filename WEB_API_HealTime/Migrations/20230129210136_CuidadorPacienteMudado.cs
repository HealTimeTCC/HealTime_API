using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class CuidadorPacienteMudado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtUltimoAcesso",
                table: "Pessoas",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNascimentoPesssoa",
                table: "Pessoas",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "CPFCuidador",
                table: "CuidadorPacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPFPacienteIncapaz",
                table: "CuidadorPacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPFResponsavel",
                table: "CuidadorPacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeCuidador",
                table: "CuidadorPacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomePacienteIncapaz",
                table: "CuidadorPacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeResponsavel",
                table: "CuidadorPacientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPFCuidador",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "CPFPacienteIncapaz",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "CPFResponsavel",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "NomeCuidador",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "NomePacienteIncapaz",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "NomeResponsavel",
                table: "CuidadorPacientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtUltimoAcesso",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNascimentoPesssoa",
                table: "Pessoas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");
        }
    }
}
