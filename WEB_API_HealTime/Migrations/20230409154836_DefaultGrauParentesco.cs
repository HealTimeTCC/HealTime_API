using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class DefaultGrauParentesco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 9, 12, 48, 36, 4, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.InsertData(
                table: "GrauParentesco",
                columns: new[] { "GrauParentescoId", "DescGrauParentesco" },
                values: new object[,]
                {
                    { 1, "Mãe" },
                    { 2, "Pai" },
                    { 3, "Filha/Filho" }
                });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 63, 49, 239, 12, 57, 87, 235, 23, 55, 22, 191, 115, 97, 146, 2, 241, 142, 143, 12, 73, 118, 139, 159, 54, 6, 88, 117, 173, 221, 230, 174, 153, 143, 254, 43, 37, 75, 196, 57, 253, 235, 60, 138, 165, 4, 174, 205, 7, 112, 11, 67, 1, 35, 214, 99, 235, 210, 190, 169, 231, 149, 214, 250, 253 }, new byte[] { 217, 142, 102, 193, 68, 213, 66, 80, 248, 105, 95, 219, 182, 82, 153, 204, 120, 43, 252, 163, 230, 223, 151, 14, 247, 131, 117, 41, 210, 207, 186, 124, 74, 26, 66, 209, 37, 20, 192, 251, 65, 106, 173, 134, 98, 139, 175, 225, 227, 238, 195, 181, 78, 207, 19, 76, 81, 249, 250, 48, 17, 75, 19, 239, 237, 38, 59, 110, 73, 76, 167, 118, 208, 188, 206, 93, 166, 176, 151, 198, 31, 127, 134, 44, 90, 193, 66, 200, 127, 176, 170, 138, 218, 180, 97, 158, 172, 213, 23, 117, 196, 13, 246, 236, 184, 77, 86, 192, 105, 62, 35, 198, 104, 26, 63, 226, 72, 215, 32, 114, 77, 173, 178, 134, 163, 83, 58, 134 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 63, 49, 239, 12, 57, 87, 235, 23, 55, 22, 191, 115, 97, 146, 2, 241, 142, 143, 12, 73, 118, 139, 159, 54, 6, 88, 117, 173, 221, 230, 174, 153, 143, 254, 43, 37, 75, 196, 57, 253, 235, 60, 138, 165, 4, 174, 205, 7, 112, 11, 67, 1, 35, 214, 99, 235, 210, 190, 169, 231, 149, 214, 250, 253 }, new byte[] { 217, 142, 102, 193, 68, 213, 66, 80, 248, 105, 95, 219, 182, 82, 153, 204, 120, 43, 252, 163, 230, 223, 151, 14, 247, 131, 117, 41, 210, 207, 186, 124, 74, 26, 66, 209, 37, 20, 192, 251, 65, 106, 173, 134, 98, 139, 175, 225, 227, 238, 195, 181, 78, 207, 19, 76, 81, 249, 250, 48, 17, 75, 19, 239, 237, 38, 59, 110, 73, 76, 167, 118, 208, 188, 206, 93, 166, 176, 151, 198, 31, 127, 134, 44, 90, 193, 66, 200, 127, 176, 170, 138, 218, 180, 97, 158, 172, 213, 23, 117, 196, 13, 246, 236, 184, 77, 86, 192, 105, 62, 35, 198, 104, 26, 63, 226, 72, 215, 32, 114, 77, 173, 178, 134, 163, 83, 58, 134 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GrauParentesco",
                keyColumn: "GrauParentescoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GrauParentesco",
                keyColumn: "GrauParentescoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GrauParentesco",
                keyColumn: "GrauParentescoId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 6, 23, 6, 35, 285, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 10, 53, 197, 174, 222, 193, 154, 101, 235, 113, 63, 212, 96, 13, 37, 12, 174, 44, 37, 153, 214, 57, 66, 152, 156, 174, 191, 214, 98, 208, 74, 15, 75, 233, 139, 217, 249, 154, 122, 237, 154, 176, 204, 48, 146, 7, 176, 204, 220, 159, 1, 24, 78, 220, 120, 28, 199, 26, 147, 103, 86, 69, 27, 221 }, new byte[] { 186, 172, 55, 201, 180, 64, 204, 174, 93, 92, 240, 231, 223, 132, 210, 192, 119, 114, 11, 244, 11, 145, 236, 176, 78, 172, 182, 151, 164, 134, 139, 217, 53, 33, 8, 11, 143, 46, 207, 79, 137, 109, 133, 234, 2, 16, 28, 46, 132, 200, 117, 14, 54, 56, 0, 81, 227, 113, 236, 40, 145, 28, 39, 112, 163, 31, 177, 214, 34, 66, 155, 74, 127, 101, 12, 125, 243, 57, 241, 210, 193, 58, 169, 55, 48, 193, 46, 160, 107, 45, 12, 40, 118, 230, 15, 206, 201, 0, 71, 179, 127, 19, 93, 79, 216, 214, 112, 111, 193, 178, 215, 183, 22, 105, 120, 208, 140, 213, 89, 15, 32, 53, 92, 43, 2, 30, 139, 30 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 10, 53, 197, 174, 222, 193, 154, 101, 235, 113, 63, 212, 96, 13, 37, 12, 174, 44, 37, 153, 214, 57, 66, 152, 156, 174, 191, 214, 98, 208, 74, 15, 75, 233, 139, 217, 249, 154, 122, 237, 154, 176, 204, 48, 146, 7, 176, 204, 220, 159, 1, 24, 78, 220, 120, 28, 199, 26, 147, 103, 86, 69, 27, 221 }, new byte[] { 186, 172, 55, 201, 180, 64, 204, 174, 93, 92, 240, 231, 223, 132, 210, 192, 119, 114, 11, 244, 11, 145, 236, 176, 78, 172, 182, 151, 164, 134, 139, 217, 53, 33, 8, 11, 143, 46, 207, 79, 137, 109, 133, 234, 2, 16, 28, 46, 132, 200, 117, 14, 54, 56, 0, 81, 227, 113, 236, 40, 145, 28, 39, 112, 163, 31, 177, 214, 34, 66, 155, 74, 127, 101, 12, 125, 243, 57, 241, 210, 193, 58, 169, 55, 48, 193, 46, 160, 107, 45, 12, 40, 118, 230, 15, 206, 201, 0, 71, 179, 127, 19, 93, 79, 216, 214, 112, 111, 193, 178, 215, 183, 22, 105, 120, 208, 140, 213, 89, 15, 32, 53, 92, 43, 2, 30, 139, 30 } });
        }
    }
}
