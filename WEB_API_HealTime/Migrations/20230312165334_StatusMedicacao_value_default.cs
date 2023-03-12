using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class StatusMedicacao_value_default : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacoes_StatusMedicacao_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicacoes_TipoMedicacao_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropTable(
                name: "StatusMedicacao");

            migrationBuilder.DropTable(
                name: "TipoMedicacao");

            migrationBuilder.CreateTable(
                name: "StatusMedicacoes",
                columns: table => new
                {
                    StatusMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusMedicacao = table.Column<string>(type: "VARCHAR(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMedicacaoId", x => x.StatusMedicacaoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposMedicacoes",
                columns: table => new
                {
                    TipoMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescMedicacao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    TituloTipoMedicacao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ClasseAplicacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedicacaoId", x => x.TipoMedicacaoId);
                });

            migrationBuilder.InsertData(
                table: "StatusMedicacoes",
                columns: new[] { "StatusMedicacaoId", "DescStatusMedicacao" },
                values: new object[,]
                {
                    { 1, "ATIVO" },
                    { 2, "INATIVO" },
                    { 3, "EFEITO COLATERAL GRAVE" },
                    { 4, "REAÇÃO GRAVE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacoes_StatusMedicacoes_StatusMedicacaoId",
                table: "Medicacoes",
                column: "StatusMedicacaoId",
                principalTable: "StatusMedicacoes",
                principalColumn: "StatusMedicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacoes_TiposMedicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                principalTable: "TiposMedicacoes",
                principalColumn: "TipoMedicacaoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacoes_StatusMedicacoes_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicacoes_TiposMedicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropTable(
                name: "StatusMedicacoes");

            migrationBuilder.DropTable(
                name: "TiposMedicacoes");

            migrationBuilder.CreateTable(
                name: "StatusMedicacao",
                columns: table => new
                {
                    StatusMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusMedicacao = table.Column<string>(type: "VARCHAR(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMedicacaoId", x => x.StatusMedicacaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMedicacao",
                columns: table => new
                {
                    TipoMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasseAplicacao = table.Column<int>(type: "int", nullable: false),
                    DescMedicacao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    TituloTipoMedicacao = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedicacaoId", x => x.TipoMedicacaoId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacoes_StatusMedicacao_StatusMedicacaoId",
                table: "Medicacoes",
                column: "StatusMedicacaoId",
                principalTable: "StatusMedicacao",
                principalColumn: "StatusMedicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacoes_TipoMedicacao_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                principalTable: "TipoMedicacao",
                principalColumn: "TipoMedicacaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
