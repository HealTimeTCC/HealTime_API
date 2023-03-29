using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 92, 169, 206, 113, 75, 62, 140, 32, 50, 135, 226, 151, 164, 214, 105, 56, 97, 10, 193, 179, 137, 93, 154, 181, 55, 94, 193, 44, 214, 210, 9, 238, 175, 59, 223, 209, 70, 4, 180, 51, 72, 161, 227, 68, 1, 203, 73, 58, 110, 28, 139, 234, 129, 51, 198, 112, 92, 17, 96, 139, 201, 24, 225, 71 }, new byte[] { 142, 124, 119, 99, 109, 221, 237, 249, 61, 191, 103, 207, 206, 175, 38, 251, 241, 199, 177, 60, 135, 99, 182, 193, 48, 224, 152, 90, 174, 19, 4, 101, 215, 85, 85, 19, 129, 52, 176, 224, 128, 7, 228, 117, 43, 159, 250, 72, 251, 213, 67, 157, 182, 20, 255, 103, 111, 6, 114, 26, 79, 188, 167, 154, 204, 20, 238, 186, 192, 177, 37, 10, 33, 115, 111, 201, 12, 230, 153, 241, 107, 21, 48, 4, 195, 11, 160, 162, 31, 239, 58, 215, 66, 71, 21, 141, 67, 25, 16, 23, 203, 148, 250, 55, 218, 148, 136, 116, 246, 111, 29, 84, 20, 247, 235, 139, 14, 68, 138, 155, 252, 8, 255, 56, 36, 3, 102, 18 } });

            migrationBuilder.UpdateData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 1,
                column: "DescStatusConsulta",
                value: "Agendada");

            migrationBuilder.UpdateData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 2,
                column: "DescStatusConsulta",
                value: "Encerrada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 196, 108, 45, 136, 136, 154, 199, 121, 14, 222, 88, 198, 102, 25, 159, 141, 134, 58, 117, 190, 114, 183, 52, 235, 61, 94, 152, 77, 232, 105, 100, 65, 91, 230, 168, 75, 66, 48, 227, 188, 207, 86, 211, 101, 69, 204, 43, 193, 20, 21, 243, 152, 174, 149, 33, 110, 104, 129, 236, 48, 249, 99, 21, 65 }, new byte[] { 84, 51, 202, 234, 37, 244, 59, 157, 203, 35, 199, 221, 74, 93, 11, 96, 176, 14, 15, 237, 83, 202, 111, 227, 184, 158, 166, 251, 83, 54, 5, 186, 228, 0, 28, 8, 79, 50, 227, 202, 65, 123, 79, 129, 42, 117, 10, 105, 237, 116, 130, 242, 167, 11, 76, 224, 209, 157, 80, 178, 224, 251, 144, 170, 242, 47, 195, 44, 92, 130, 125, 254, 142, 20, 7, 68, 157, 242, 9, 190, 66, 241, 79, 49, 211, 124, 33, 255, 251, 1, 90, 118, 202, 52, 197, 209, 211, 182, 225, 145, 146, 155, 58, 237, 24, 180, 101, 11, 197, 84, 50, 77, 95, 243, 190, 19, 239, 215, 60, 65, 97, 89, 238, 205, 138, 126, 194, 91 } });

            migrationBuilder.UpdateData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 1,
                column: "DescStatusConsulta",
                value: "Encerrada");

            migrationBuilder.UpdateData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 2,
                column: "DescStatusConsulta",
                value: "Agendada");
        }
    }
}
