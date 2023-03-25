using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class Create_Especialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescEspecialidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeId", x => x.EspecialidadeId);
                });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 84, 196, 101, 235, 70, 42, 193, 114, 198, 213, 161, 99, 24, 228, 196, 93, 137, 128, 243, 254, 60, 34, 8, 141, 233, 204, 38, 121, 80, 75, 221, 202, 35, 80, 163, 189, 130, 123, 173, 27, 97, 41, 46, 91, 3, 90, 66, 184, 64, 96, 230, 180, 226, 8, 236, 69, 129, 110, 237, 45, 53, 41, 51, 120 }, new byte[] { 49, 236, 69, 221, 124, 121, 1, 71, 217, 23, 205, 56, 22, 244, 94, 157, 74, 33, 76, 250, 74, 242, 137, 59, 152, 175, 3, 75, 161, 82, 200, 239, 177, 196, 132, 120, 216, 239, 38, 89, 96, 39, 120, 222, 112, 234, 103, 208, 99, 79, 49, 124, 217, 147, 23, 187, 206, 54, 74, 216, 83, 73, 145, 182, 73, 188, 139, 105, 207, 182, 233, 57, 18, 117, 220, 255, 233, 222, 150, 110, 114, 141, 145, 235, 60, 199, 146, 208, 109, 181, 224, 230, 198, 144, 179, 122, 233, 103, 46, 215, 64, 170, 41, 133, 234, 103, 55, 219, 72, 216, 233, 198, 105, 22, 118, 98, 18, 229, 155, 69, 138, 127, 114, 255, 140, 5, 237, 114 } });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_EspecialidadeId",
                table: "ConsultasAgendadas",
                column: "EspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecialidadeId",
                table: "ConsultasAgendadas",
                column: "EspecialidadeId",
                principalTable: "Especialidades",
                principalColumn: "EspecialidadeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecialidadeId",
                table: "ConsultasAgendadas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasAgendadas_EspecialidadeId",
                table: "ConsultasAgendadas");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 126, 220, 248, 32, 85, 245, 29, 158, 243, 55, 23, 165, 13, 186, 243, 12, 248, 152, 206, 242, 144, 91, 124, 254, 249, 144, 126, 28, 72, 0, 221, 39, 36, 94, 183, 124, 198, 225, 58, 172, 238, 93, 141, 107, 69, 31, 105, 91, 111, 70, 187, 92, 62, 190, 232, 14, 36, 59, 88, 222, 155, 194, 76, 144 }, new byte[] { 5, 161, 15, 57, 51, 64, 112, 133, 143, 157, 250, 19, 196, 79, 163, 162, 48, 247, 5, 203, 28, 159, 249, 6, 230, 80, 100, 11, 182, 233, 215, 117, 211, 219, 228, 122, 96, 212, 237, 33, 73, 84, 74, 116, 16, 166, 238, 133, 168, 222, 208, 140, 43, 248, 105, 220, 28, 172, 131, 31, 3, 150, 132, 162, 173, 12, 73, 213, 60, 129, 197, 100, 161, 200, 83, 11, 176, 83, 148, 21, 22, 99, 143, 83, 101, 124, 104, 26, 182, 15, 155, 18, 231, 77, 233, 148, 170, 136, 172, 203, 243, 200, 28, 238, 125, 252, 90, 85, 148, 165, 116, 247, 139, 180, 182, 25, 165, 77, 189, 38, 205, 155, 60, 239, 25, 99, 84, 228 } });
        }
    }
}
