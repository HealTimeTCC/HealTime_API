using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class Relathion_N1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ConsultasAgendadas_MedicoId",
                table: "ConsultasAgendadas");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 120, 69, 244, 193, 161, 187, 9, 11, 18, 135, 203, 8, 125, 135, 175, 99, 70, 131, 224, 235, 131, 247, 68, 251, 88, 64, 101, 98, 67, 249, 0, 252, 235, 43, 94, 202, 176, 121, 217, 119, 181, 78, 50, 211, 29, 86, 114, 123, 159, 106, 54, 214, 194, 109, 73, 101, 213, 221, 33, 99, 136, 95, 189, 229 }, new byte[] { 238, 148, 223, 189, 48, 22, 89, 32, 39, 64, 197, 16, 126, 140, 78, 124, 228, 139, 159, 131, 75, 201, 146, 164, 59, 67, 185, 211, 1, 21, 129, 157, 151, 93, 255, 5, 123, 111, 181, 44, 138, 120, 140, 202, 127, 70, 123, 16, 198, 238, 23, 13, 136, 81, 217, 130, 54, 36, 4, 88, 113, 93, 62, 42, 87, 25, 210, 45, 18, 109, 187, 30, 81, 199, 34, 69, 203, 129, 54, 130, 147, 112, 184, 241, 206, 79, 216, 120, 18, 98, 207, 214, 172, 252, 166, 212, 133, 109, 39, 119, 62, 240, 114, 47, 115, 38, 25, 29, 58, 149, 48, 12, 72, 74, 179, 233, 207, 101, 143, 92, 242, 44, 84, 170, 49, 29, 154, 210 } });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_MedicoId",
                table: "ConsultasAgendadas",
                column: "MedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ConsultasAgendadas_MedicoId",
                table: "ConsultasAgendadas");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 101, 168, 187, 248, 58, 121, 104, 79, 205, 104, 153, 143, 26, 233, 109, 231, 96, 203, 84, 151, 162, 106, 231, 185, 90, 119, 6, 62, 213, 227, 54, 176, 227, 5, 148, 244, 0, 13, 159, 223, 252, 162, 182, 181, 183, 27, 12, 125, 46, 151, 254, 27, 163, 131, 125, 129, 26, 32, 244, 158, 128, 55, 243, 224 }, new byte[] { 247, 85, 38, 41, 131, 247, 24, 180, 150, 182, 159, 102, 195, 114, 66, 8, 250, 144, 202, 68, 83, 66, 174, 49, 27, 237, 6, 197, 148, 203, 76, 57, 22, 76, 119, 126, 66, 242, 29, 57, 142, 18, 139, 175, 202, 52, 201, 228, 95, 98, 240, 219, 127, 142, 122, 85, 92, 174, 150, 27, 130, 242, 136, 45, 222, 164, 88, 169, 27, 219, 43, 188, 122, 238, 116, 59, 102, 182, 236, 67, 189, 6, 86, 162, 15, 207, 195, 103, 71, 107, 34, 77, 57, 253, 123, 228, 16, 44, 208, 203, 132, 163, 8, 246, 183, 150, 156, 35, 240, 164, 210, 12, 147, 110, 234, 115, 117, 238, 209, 30, 226, 32, 78, 123, 251, 40, 15, 131 } });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_MedicoId",
                table: "ConsultasAgendadas",
                column: "MedicoId",
                unique: true);
        }
    }
}
