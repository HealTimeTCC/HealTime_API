using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class novo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PrescricaoMedicamento",
                newName: "PrescricaoMedicamentos");

            migrationBuilder.RenameColumn(
                name: "Emissao",
                table: "PrescricaoPacientes",
                newName: "EmissaoPrescricao");

            migrationBuilder.RenameColumn(
                name: "HrDtMedicacao",
                table: "PrescricaoMedicamentos",
                newName: "HrInicioDtMedicacao");

            migrationBuilder.RenameIndex(
                name: "IX_PrescricaoMedicamento_PrescricaoPacienteId",
                table: "PrescricaoMedicamentos",
                newName: "IX_PrescricaoMedicamentos_PrescricaoPacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_PrescricaoMedicamento_MedicacaoId",
                table: "PrescricaoMedicamentos",
                newName: "IX_PrescricaoMedicamentos_MedicacaoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastroSistemaPrescricao",
                table: "PrescricaoPacientes",
                type: "SMALLDATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Pessoas",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Pessoas",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntervaloMedicacao",
                table: "PrescricaoMedicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeMedicamento",
                table: "PrescricaoMedicamentos",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastroSistemaPrescricao",
                table: "PrescricaoPacientes");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "IntervaloMedicacao",
                table: "PrescricaoMedicamentos");

            migrationBuilder.DropColumn(
                name: "NomeMedicamento",
                table: "PrescricaoMedicamentos");

            migrationBuilder.RenameTable(
                name: "PrescricaoMedicamentos",
                newName: "PrescricaoMedicamento");

            migrationBuilder.RenameColumn(
                name: "EmissaoPrescricao",
                table: "PrescricaoPacientes",
                newName: "Emissao");

            migrationBuilder.RenameColumn(
                name: "HrInicioDtMedicacao",
                table: "PrescricaoMedicamento",
                newName: "HrDtMedicacao");

            migrationBuilder.RenameIndex(
                name: "IX_PrescricaoMedicamentos_PrescricaoPacienteId",
                table: "PrescricaoMedicamento",
                newName: "IX_PrescricaoMedicamento_PrescricaoPacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_PrescricaoMedicamentos_MedicacaoId",
                table: "PrescricaoMedicamento",
                newName: "IX_PrescricaoMedicamento_MedicacaoId");
        }
    }
}
