using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class ForeingKeyEmDoisAtributos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_PessoasPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropIndex(
                name: "IX_CuidadorPacientes_PessoasPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.RenameColumn(
                name: "PessoasPessoaId",
                table: "CuidadorPacientes",
                newName: "PacienteIncapazId");

            migrationBuilder.RenameColumn(
                name: "PacienteIncapaz",
                table: "CuidadorPacientes",
                newName: "IdPacienteIncapazPessoaId");

            migrationBuilder.AddColumn<string>(
                name: "IdCuidadorPessoaId",
                table: "CuidadorPacientes",
                type: "varchar(40)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_IdCuidadorPessoaId",
                table: "CuidadorPacientes",
                column: "IdCuidadorPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_IdPacienteIncapazPessoaId",
                table: "CuidadorPacientes",
                column: "IdPacienteIncapazPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_IdCuidadorPessoaId",
                table: "CuidadorPacientes",
                column: "IdCuidadorPessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_IdPacienteIncapazPessoaId",
                table: "CuidadorPacientes",
                column: "IdPacienteIncapazPessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_IdCuidadorPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_IdPacienteIncapazPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropIndex(
                name: "IX_CuidadorPacientes_IdCuidadorPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropIndex(
                name: "IX_CuidadorPacientes_IdPacienteIncapazPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "IdCuidadorPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.RenameColumn(
                name: "PacienteIncapazId",
                table: "CuidadorPacientes",
                newName: "PessoasPessoaId");

            migrationBuilder.RenameColumn(
                name: "IdPacienteIncapazPessoaId",
                table: "CuidadorPacientes",
                newName: "PacienteIncapaz");

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_PessoasPessoaId",
                table: "CuidadorPacientes",
                column: "PessoasPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_PessoasPessoaId",
                table: "CuidadorPacientes",
                column: "PessoasPessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId");
        }
    }
}
