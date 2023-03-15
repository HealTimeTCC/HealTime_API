using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class ResolvendoQuestaoEnumStatusMedicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacao_StatusMedicacao",
                table: "Medicacoes");

            migrationBuilder.DropTable(
                name: "StatusMedicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropColumn(
                name: "StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.AddColumn<string>(
                name: "FlagStatus",
                table: "PrescricaoPacientes",
                type: "CHAR(1)",
                nullable: false,
                defaultValue: "S");

            migrationBuilder.AddColumn<int>(
                name: "StatusMedicacao",
                table: "Medicacoes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 89, 189, 97, 151, 94, 166, 49, 39, 164, 171, 0, 118, 139, 36, 2, 56, 2, 242, 29, 106, 100, 161, 88, 134, 57, 176, 136, 18, 242, 199, 244, 109, 190, 98, 53, 106, 158, 147, 221, 132, 81, 246, 89, 219, 139, 116, 109, 153, 109, 87, 70, 243, 189, 188, 226, 39, 150, 21, 73, 184, 133, 195, 181, 178 }, new byte[] { 109, 68, 88, 183, 29, 207, 19, 44, 194, 219, 49, 151, 100, 5, 145, 34, 40, 186, 45, 65, 170, 65, 178, 210, 146, 142, 18, 55, 235, 4, 99, 188, 155, 134, 163, 75, 198, 203, 55, 203, 113, 60, 162, 117, 253, 92, 177, 215, 206, 110, 197, 205, 251, 165, 127, 197, 252, 218, 158, 82, 31, 228, 206, 110, 99, 114, 237, 179, 192, 255, 173, 186, 54, 41, 111, 215, 61, 193, 93, 196, 221, 124, 28, 29, 130, 254, 9, 218, 25, 202, 19, 87, 142, 146, 243, 77, 192, 239, 131, 126, 195, 62, 119, 173, 174, 218, 161, 174, 240, 190, 249, 160, 0, 155, 93, 250, 83, 144, 186, 40, 213, 93, 102, 79, 3, 226, 52, 212 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagStatus",
                table: "PrescricaoPacientes");

            migrationBuilder.DropColumn(
                name: "StatusMedicacao",
                table: "Medicacoes");

            migrationBuilder.AddColumn<int>(
                name: "StatusMedicacaoId",
                table: "Medicacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 81, 42, 33, 218, 83, 126, 140, 104, 217, 193, 137, 248, 13, 163, 203, 135, 61, 252, 134, 69, 241, 118, 60, 201, 190, 42, 68, 52, 174, 183, 241, 84, 81, 119, 42, 171, 112, 166, 12, 125, 190, 194, 74, 143, 150, 252, 46, 73, 127, 41, 203, 31, 129, 74, 159, 90, 84, 240, 30, 215, 185, 0, 27, 63 }, new byte[] { 180, 29, 149, 236, 129, 225, 150, 168, 44, 157, 173, 88, 17, 152, 129, 21, 111, 186, 50, 99, 76, 24, 51, 141, 156, 108, 46, 97, 235, 237, 0, 236, 164, 210, 90, 143, 60, 65, 80, 157, 155, 74, 252, 244, 179, 86, 110, 66, 28, 115, 13, 12, 199, 48, 163, 151, 66, 23, 175, 72, 21, 130, 245, 201, 144, 71, 247, 242, 239, 227, 84, 130, 1, 236, 242, 211, 39, 171, 254, 117, 42, 128, 108, 217, 62, 4, 155, 150, 255, 5, 146, 15, 186, 109, 114, 34, 204, 179, 185, 161, 65, 133, 46, 16, 232, 84, 237, 22, 56, 113, 119, 49, 226, 149, 51, 115, 8, 137, 18, 250, 23, 200, 201, 168, 215, 100, 178, 94 } });

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

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes",
                column: "StatusMedicacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacao_StatusMedicacao",
                table: "Medicacoes",
                column: "StatusMedicacaoId",
                principalTable: "StatusMedicacoes",
                principalColumn: "StatusMedicacaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
