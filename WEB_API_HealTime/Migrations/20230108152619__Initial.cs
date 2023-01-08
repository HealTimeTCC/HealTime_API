using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<string>(type: "varchar(40)", nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    NomePessoa = table.Column<string>(type: "varchar(25)", nullable: false),
                    SobrenomePessoa = table.Column<string>(type: "varchar(40)", nullable: false),
                    CpfPessoa = table.Column<string>(type: "char(11)", nullable: false),
                    DtUltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtNascimentoPesssoa = table.Column<DateTime>(type: "date", nullable: false),
                    GeneroPessoa = table.Column<int>(type: "int", nullable: false),
                    ObsPacienteIncapaz = table.Column<string>(type: "varchar(350)", nullable: true),
                    EnderecoPessoa = table.Column<string>(type: "varchar(45)", nullable: false),
                    BairroEnderecoPessoa = table.Column<string>(type: "varchar(30)", nullable: false),
                    CidadeEnderecoPessoa = table.Column<string>(type: "varchar(20)", nullable: false),
                    ComplementoPessoa = table.Column<string>(type: "varchar(45)", nullable: true),
                    CepEndereco = table.Column<string>(type: "char(8)", nullable: false),
                    UfEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
