using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoUniqueContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 2, 18, 38, 2, 825, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 163, 130, 154, 114, 31, 170, 42, 108, 157, 2, 131, 240, 149, 229, 52, 169, 187, 221, 141, 188, 42, 247, 99, 30, 111, 232, 54, 33, 54, 200, 64, 70, 108, 245, 147, 71, 42, 91, 43, 230, 205, 41, 60, 241, 158, 82, 158, 144, 244, 20, 236, 195, 7, 39, 201, 180, 199, 166, 92, 232, 203, 195, 15, 74 }, new byte[] { 147, 144, 182, 39, 85, 64, 139, 206, 165, 30, 233, 1, 234, 42, 2, 87, 62, 208, 10, 56, 76, 13, 34, 136, 194, 133, 135, 38, 44, 191, 102, 205, 190, 217, 224, 45, 50, 53, 14, 226, 13, 88, 223, 190, 157, 220, 168, 32, 240, 218, 220, 167, 203, 142, 11, 136, 197, 42, 229, 245, 219, 232, 103, 206, 220, 125, 114, 35, 129, 170, 176, 155, 86, 40, 129, 101, 86, 102, 34, 164, 7, 54, 181, 145, 209, 76, 159, 85, 74, 253, 181, 163, 154, 97, 215, 131, 216, 140, 195, 139, 209, 155, 128, 248, 85, 54, 5, 239, 18, 9, 6, 190, 169, 229, 92, 181, 68, 156, 123, 21, 90, 89, 19, 39, 210, 142, 21, 243 } });

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPessoas_Celular",
                table: "ContatoPessoas",
                column: "Celular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContatoPessoas_Celular",
                table: "ContatoPessoas");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 2, 16, 18, 27, 997, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 249, 39, 1, 236, 202, 205, 140, 4, 26, 90, 87, 123, 232, 208, 67, 218, 195, 100, 155, 65, 63, 114, 249, 204, 202, 98, 112, 100, 162, 74, 135, 233, 176, 132, 175, 81, 29, 52, 136, 189, 229, 126, 71, 108, 76, 81, 123, 61, 79, 159, 164, 232, 36, 72, 67, 18, 16, 248, 80, 220, 17, 3, 75, 147 }, new byte[] { 82, 156, 67, 44, 171, 192, 186, 21, 165, 73, 150, 47, 119, 242, 160, 202, 190, 235, 27, 161, 86, 63, 128, 210, 191, 140, 206, 36, 175, 239, 152, 217, 249, 206, 13, 245, 227, 56, 204, 82, 155, 254, 22, 114, 29, 248, 111, 95, 255, 20, 81, 47, 186, 36, 182, 148, 13, 43, 17, 131, 178, 125, 16, 32, 13, 239, 227, 215, 102, 32, 195, 33, 126, 31, 162, 168, 105, 233, 112, 32, 130, 201, 245, 4, 146, 140, 40, 27, 211, 205, 67, 164, 120, 212, 254, 117, 30, 55, 222, 21, 226, 171, 152, 237, 95, 20, 26, 34, 5, 88, 222, 222, 153, 154, 234, 74, 239, 15, 231, 162, 51, 234, 163, 204, 53, 99, 193, 123 } });
        }
    }
}
