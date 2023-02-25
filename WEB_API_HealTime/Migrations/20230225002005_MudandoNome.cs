using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class MudandoNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastroSistemaPrescricao",
                table: "PrescricaoPacientes",
                newName: "DataCadastroSistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastroSistema",
                table: "PrescricaoPacientes",
                newName: "DataCadastroSistemaPrescricao");
        }
    }
}
