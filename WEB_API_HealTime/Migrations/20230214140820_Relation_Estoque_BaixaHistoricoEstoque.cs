using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class RelationEstoqueBaixaHistoricoEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "AndamentoMedicacao",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "BaixaHistoricoEstoque",
                columns: table => new
                {
                    BaixaHistoricoEstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstoqueId = table.Column<int>(type: "int", nullable: false),
                    BaixaEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DescBaixa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaixaHistoricoEstoqueId", x => x.BaixaHistoricoEstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoque_BaixaHistoricoEstoques",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "MedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaixaHistoricoEstoque_EstoqueId",
                table: "BaixaHistoricoEstoque",
                column: "EstoqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaixaHistoricoEstoque");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "AndamentoMedicacao",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
