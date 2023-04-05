using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class Atualizando_TypeNroLogradouro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NroLogradouro",
                table: "EnderecoPessoas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 4, 20, 17, 40, 244, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 255, 20, 153, 105, 190, 113, 138, 3, 163, 173, 185, 234, 107, 92, 29, 2, 227, 118, 17, 191, 91, 213, 1, 204, 6, 24, 136, 228, 202, 47, 118, 199, 74, 225, 113, 11, 31, 5, 34, 81, 208, 91, 215, 78, 178, 104, 217, 94, 165, 129, 90, 209, 136, 158, 74, 71, 167, 129, 59, 205, 140, 240, 20, 205 }, new byte[] { 166, 215, 57, 46, 74, 84, 85, 34, 123, 235, 157, 95, 77, 188, 186, 100, 68, 110, 97, 27, 117, 128, 66, 4, 174, 70, 192, 156, 35, 98, 155, 117, 160, 108, 9, 46, 28, 182, 202, 112, 54, 112, 152, 140, 239, 91, 94, 252, 4, 244, 164, 215, 250, 230, 246, 38, 160, 141, 151, 205, 111, 246, 203, 155, 96, 225, 47, 224, 100, 215, 174, 97, 151, 55, 173, 243, 220, 5, 103, 187, 133, 254, 209, 101, 137, 182, 210, 65, 221, 167, 87, 84, 65, 112, 155, 151, 68, 63, 84, 110, 78, 179, 75, 209, 142, 0, 145, 251, 139, 31, 9, 230, 19, 231, 39, 190, 239, 249, 160, 211, 17, 78, 104, 187, 48, 96, 214, 209 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NroLogradouro",
                table: "EnderecoPessoas",
                type: "VARCHAR(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

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
        }
    }
}
