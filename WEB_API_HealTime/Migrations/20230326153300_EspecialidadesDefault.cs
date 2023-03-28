using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class EspecialidadesDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescEspecialidade",
                table: "Especialidades",
                type: "VARCHAR(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "EspecialidadeId", "DescEspecialidade" },
                values: new object[,]
                {
                    { 1, "Cardiologia" },
                    { 2, "Dermatologia" },
                    { 3, "Ginecologia/Obstetrícia" },
                    { 4, "Ortopedia" },
                    { 5, "Anestesiologia" },
                    { 6, "Pediatria" },
                    { 7, "Oftalmologia" },
                    { 8, "Psiquiatria" },
                    { 9, "Urologia" },
                    { 10, "Oncologia" },
                    { 11, "Endocrinologia" },
                    { 12, "Neurologia" },
                    { 13, "Hematologia" },
                    { 14, "Cirurgia Plástica" }
                });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 128, 235, 171, 166, 185, 233, 109, 229, 173, 73, 111, 236, 178, 201, 202, 243, 100, 246, 198, 102, 179, 251, 202, 65, 251, 172, 205, 227, 200, 187, 22, 65, 2, 99, 80, 158, 60, 185, 55, 64, 207, 24, 91, 127, 38, 180, 156, 61, 188, 179, 47, 159, 181, 224, 163, 111, 39, 205, 252, 56, 143, 19, 195 }, new byte[] { 103, 52, 87, 58, 7, 160, 117, 226, 132, 57, 134, 222, 246, 86, 125, 64, 47, 185, 251, 169, 145, 3, 131, 150, 139, 122, 252, 206, 173, 178, 137, 232, 19, 250, 234, 210, 244, 216, 10, 85, 162, 227, 130, 124, 141, 116, 207, 24, 179, 82, 202, 82, 75, 229, 50, 167, 147, 156, 94, 33, 178, 244, 222, 242, 67, 3, 159, 88, 94, 237, 70, 176, 121, 30, 138, 161, 88, 179, 32, 119, 222, 134, 241, 31, 253, 93, 75, 224, 123, 25, 20, 210, 62, 104, 205, 42, 112, 231, 242, 202, 121, 131, 196, 154, 102, 65, 96, 226, 253, 40, 189, 233, 208, 114, 79, 230, 79, 40, 137, 191, 149, 25, 5, 239, 200, 36, 185, 209 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "EspecialidadeId",
                keyValue: 14);

            migrationBuilder.AlterColumn<string>(
                name: "DescEspecialidade",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(25)");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 120, 69, 244, 193, 161, 187, 9, 11, 18, 135, 203, 8, 125, 135, 175, 99, 70, 131, 224, 235, 131, 247, 68, 251, 88, 64, 101, 98, 67, 249, 0, 252, 235, 43, 94, 202, 176, 121, 217, 119, 181, 78, 50, 211, 29, 86, 114, 123, 159, 106, 54, 214, 194, 109, 73, 101, 213, 221, 33, 99, 136, 95, 189, 229 }, new byte[] { 238, 148, 223, 189, 48, 22, 89, 32, 39, 64, 197, 16, 126, 140, 78, 124, 228, 139, 159, 131, 75, 201, 146, 164, 59, 67, 185, 211, 1, 21, 129, 157, 151, 93, 255, 5, 123, 111, 181, 44, 138, 120, 140, 202, 127, 70, 123, 16, 198, 238, 23, 13, 136, 81, 217, 130, 54, 36, 4, 88, 113, 93, 62, 42, 87, 25, 210, 45, 18, 109, 187, 30, 81, 199, 34, 69, 203, 129, 54, 130, 147, 112, 184, 241, 206, 79, 216, 120, 18, 98, 207, 214, 172, 252, 166, 212, 133, 109, 39, 119, 62, 240, 114, 47, 115, 38, 25, 29, 58, 149, 48, 12, 72, 74, 179, 233, 207, 101, 143, 92, 242, 44, 84, 170, 49, 29, 154, 210 } });
        }
    }
}
