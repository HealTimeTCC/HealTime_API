using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class ImplementandoCuidadorPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContatoPessoas_Pessoas_PessoaId",
                table: "ContatoPessoas");

            migrationBuilder.DropIndex(
                name: "IX_ContatoPessoas_PessoaId",
                table: "ContatoPessoas");

            migrationBuilder.AlterColumn<string>(
                name: "PessoaId",
                table: "ContatoPessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PessoaId",
                table: "ContatoPessoas",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPessoas_PessoaId",
                table: "ContatoPessoas",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContatoPessoas_Pessoas_PessoaId",
                table: "ContatoPessoas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId");
        }
    }
}
