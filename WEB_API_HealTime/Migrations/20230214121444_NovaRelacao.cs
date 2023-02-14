using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class NovaRelacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    MedicacaoId = table.Column<int>(type: "int", nullable: false),
                    QtdEstoque = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque_MedicacaoId", x => x.MedicacaoId);
                    table.ForeignKey(
                        name: "FK_Estoque_Medicacoes",
                        column: x => x.MedicacaoId,
                        principalTable: "Medicacoes",
                        principalColumn: "MedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");
        }
    }
}
