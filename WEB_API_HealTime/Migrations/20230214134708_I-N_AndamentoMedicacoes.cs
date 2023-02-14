using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class INAndamentoMedicacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CheckSituacao",
                table: "PrescricaoMedicamento",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estoque",
                type: "VARCHAR(40)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Estoque",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Estoque",
                type: "SMALLDATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Estoque",
                type: "SMALLDATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "AndamentoMedicacao",
                columns: table => new
                {
                    AndamentoMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescricaoMedicamentoId = table.Column<int>(type: "int", nullable: false),
                    QtdInicial = table.Column<int>(type: "int", nullable: false),
                    QtdAtual = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndamentoMedicacaoId", x => x.AndamentoMedicacaoId);
                    table.ForeignKey(
                        name: "FK_PrescricaoMedicamentoId",
                        column: x => x.PrescricaoMedicamentoId,
                        principalTable: "PrescricaoMedicamento",
                        principalColumn: "PrescricaoMedicamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoMedicacao_PrescricaoMedicamentoId",
                table: "AndamentoMedicacao",
                column: "PrescricaoMedicamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AndamentoMedicacao");

            migrationBuilder.AlterColumn<bool>(
                name: "CheckSituacao",
                table: "PrescricaoMedicamento",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estoque",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(40)");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Estoque",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Estoque",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Estoque",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
