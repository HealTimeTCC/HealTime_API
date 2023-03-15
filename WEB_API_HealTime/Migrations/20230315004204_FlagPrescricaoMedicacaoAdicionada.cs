using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class FlagPrescricaoMedicacaoAdicionada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusMedicacaoFlag",
                table: "PrescricoesMedicacoes",
                type: "CHAR(1)",
                nullable: true,
                defaultValue: "S");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 106, 70, 145, 238, 164, 217, 97, 65, 11, 34, 128, 140, 46, 231, 190, 84, 60, 82, 203, 149, 200, 194, 74, 125, 51, 231, 245, 1, 55, 1, 218, 127, 242, 22, 231, 168, 15, 96, 22, 119, 198, 244, 63, 206, 102, 108, 80, 56, 0, 99, 248, 164, 210, 243, 225, 8, 172, 197, 150, 18, 146, 218, 223, 102 }, new byte[] { 24, 13, 161, 88, 78, 190, 33, 243, 56, 138, 98, 160, 206, 244, 111, 222, 113, 170, 48, 66, 55, 74, 199, 199, 88, 7, 108, 52, 118, 92, 189, 148, 151, 159, 70, 129, 250, 18, 88, 198, 141, 151, 70, 141, 218, 185, 89, 30, 167, 74, 61, 143, 195, 117, 82, 207, 224, 172, 135, 109, 16, 203, 107, 132, 171, 21, 164, 154, 24, 121, 200, 24, 101, 166, 116, 124, 36, 176, 34, 184, 78, 186, 102, 44, 25, 103, 66, 185, 22, 93, 112, 173, 11, 233, 2, 150, 54, 221, 65, 12, 221, 66, 197, 47, 233, 188, 74, 70, 245, 74, 141, 222, 249, 251, 155, 64, 191, 25, 51, 159, 61, 190, 165, 183, 187, 88, 49, 7 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusMedicacaoFlag",
                table: "PrescricoesMedicacoes");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 89, 189, 97, 151, 94, 166, 49, 39, 164, 171, 0, 118, 139, 36, 2, 56, 2, 242, 29, 106, 100, 161, 88, 134, 57, 176, 136, 18, 242, 199, 244, 109, 190, 98, 53, 106, 158, 147, 221, 132, 81, 246, 89, 219, 139, 116, 109, 153, 109, 87, 70, 243, 189, 188, 226, 39, 150, 21, 73, 184, 133, 195, 181, 178 }, new byte[] { 109, 68, 88, 183, 29, 207, 19, 44, 194, 219, 49, 151, 100, 5, 145, 34, 40, 186, 45, 65, 170, 65, 178, 210, 146, 142, 18, 55, 235, 4, 99, 188, 155, 134, 163, 75, 198, 203, 55, 203, 113, 60, 162, 117, 253, 92, 177, 215, 206, 110, 197, 205, 251, 165, 127, 197, 252, 218, 158, 82, 31, 228, 206, 110, 99, 114, 237, 179, 192, 255, 173, 186, 54, 41, 111, 215, 61, 193, 93, 196, 221, 124, 28, 29, 130, 254, 9, 218, 25, 202, 19, 87, 142, 146, 243, 77, 192, 239, 131, 126, 195, 62, 119, 173, 174, 218, 161, 174, 240, 190, 249, 160, 0, 155, 93, 250, 83, 144, 186, 40, 213, 93, 102, 79, 3, 226, 52, 212 } });
        }
    }
}
