using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class ImplementandoCuidadorPacienteImplementandoJSONIGNORE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PessoasPessoaId",
                table: "CuidadorPacientes",
                type: "varchar(40)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuidadorPacientes_Pessoas_PessoasPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropIndex(
                name: "IX_CuidadorPacientes_PessoasPessoaId",
                table: "CuidadorPacientes");

            migrationBuilder.DropColumn(
                name: "PessoasPessoaId",
                table: "CuidadorPacientes");
        }
    }
}
