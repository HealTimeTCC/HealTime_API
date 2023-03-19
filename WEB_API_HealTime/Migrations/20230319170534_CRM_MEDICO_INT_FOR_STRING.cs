using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class CRM_MEDICO_INT_FOR_STRING : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CrmMedico",
                table: "Medicos",
                type: "CHAR(6)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "MedicoId",
                keyValue: 1,
                column: "CrmMedico",
                value: "054321");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "MedicoId",
                keyValue: 2,
                column: "CrmMedico",
                value: "012345");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 232, 25, 35, 211, 168, 216, 139, 52, 47, 214, 57, 196, 83, 161, 38, 156, 125, 216, 181, 123, 163, 83, 96, 233, 85, 143, 142, 154, 46, 187, 147, 49, 157, 117, 153, 132, 208, 89, 225, 42, 22, 190, 176, 1, 46, 33, 142, 29, 218, 14, 255, 95, 197, 181, 164, 124, 58, 110, 176, 85, 173, 204, 248, 202 }, new byte[] { 67, 87, 137, 1, 231, 223, 240, 40, 244, 225, 54, 240, 18, 111, 241, 215, 45, 146, 178, 8, 20, 34, 66, 147, 154, 249, 148, 197, 113, 8, 37, 126, 151, 67, 127, 148, 132, 224, 2, 204, 55, 85, 148, 15, 238, 164, 12, 207, 191, 78, 99, 248, 139, 2, 232, 10, 72, 152, 131, 103, 170, 9, 163, 242, 110, 212, 5, 213, 244, 98, 223, 234, 81, 16, 157, 221, 162, 234, 82, 247, 88, 236, 4, 110, 55, 255, 11, 169, 237, 239, 22, 96, 34, 218, 103, 224, 233, 240, 195, 74, 251, 31, 122, 29, 233, 63, 98, 198, 65, 72, 239, 163, 11, 163, 204, 113, 54, 77, 32, 57, 36, 74, 170, 138, 27, 161, 53, 151 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CrmMedico",
                table: "Medicos",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "CHAR(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "MedicoId",
                keyValue: 1,
                column: "CrmMedico",
                value: 12345);

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "MedicoId",
                keyValue: 2,
                column: "CrmMedico",
                value: 12345);

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 106, 70, 145, 238, 164, 217, 97, 65, 11, 34, 128, 140, 46, 231, 190, 84, 60, 82, 203, 149, 200, 194, 74, 125, 51, 231, 245, 1, 55, 1, 218, 127, 242, 22, 231, 168, 15, 96, 22, 119, 198, 244, 63, 206, 102, 108, 80, 56, 0, 99, 248, 164, 210, 243, 225, 8, 172, 197, 150, 18, 146, 218, 223, 102 }, new byte[] { 24, 13, 161, 88, 78, 190, 33, 243, 56, 138, 98, 160, 206, 244, 111, 222, 113, 170, 48, 66, 55, 74, 199, 199, 88, 7, 108, 52, 118, 92, 189, 148, 151, 159, 70, 129, 250, 18, 88, 198, 141, 151, 70, 141, 218, 185, 89, 30, 167, 74, 61, 143, 195, 117, 82, 207, 224, 172, 135, 109, 16, 203, 107, 132, 171, 21, 164, 154, 24, 121, 200, 24, 101, 166, 116, 124, 36, 176, 34, 184, 78, 186, 102, 44, 25, 103, 66, 185, 22, 93, 112, 173, 11, 233, 2, 150, 54, 221, 65, 12, 221, 66, 197, 47, 233, 188, 74, 70, 245, 74, 141, 222, 249, 251, 155, 64, 191, 25, 51, 159, 61, 190, 165, 183, 187, 88, 49, 7 } });
        }
    }
}
