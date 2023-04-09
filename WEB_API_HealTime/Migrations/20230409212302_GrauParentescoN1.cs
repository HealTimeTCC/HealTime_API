using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class GrauParentescoN1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResponsaveisPacientes_GrauParentescoId",
                table: "ResponsaveisPacientes");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 9, 18, 23, 2, 587, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 211, 44, 220, 51, 213, 167, 198, 242, 85, 95, 237, 161, 159, 213, 197, 142, 240, 15, 201, 212, 58, 160, 110, 199, 137, 203, 102, 40, 157, 15, 135, 40, 211, 133, 53, 232, 156, 116, 131, 201, 3, 59, 19, 15, 173, 111, 179, 9, 100, 115, 197, 228, 91, 72, 121, 255, 139, 49, 81, 7, 237, 86, 62 }, new byte[] { 112, 114, 220, 25, 135, 245, 82, 72, 78, 91, 53, 40, 120, 210, 29, 254, 168, 243, 69, 148, 91, 18, 54, 41, 231, 167, 237, 37, 171, 117, 119, 253, 8, 219, 238, 222, 21, 10, 23, 33, 11, 95, 135, 5, 104, 223, 54, 77, 147, 59, 104, 194, 247, 138, 242, 28, 144, 102, 223, 103, 68, 99, 174, 73, 82, 240, 9, 251, 121, 103, 16, 6, 252, 169, 154, 217, 29, 236, 19, 213, 119, 231, 8, 188, 102, 229, 106, 186, 61, 185, 96, 68, 123, 181, 204, 64, 152, 18, 85, 201, 83, 70, 153, 142, 55, 248, 196, 66, 170, 62, 63, 204, 40, 183, 154, 19, 123, 114, 8, 130, 224, 54, 20, 33, 60, 171, 236, 211 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 211, 44, 220, 51, 213, 167, 198, 242, 85, 95, 237, 161, 159, 213, 197, 142, 240, 15, 201, 212, 58, 160, 110, 199, 137, 203, 102, 40, 157, 15, 135, 40, 211, 133, 53, 232, 156, 116, 131, 201, 3, 59, 19, 15, 173, 111, 179, 9, 100, 115, 197, 228, 91, 72, 121, 255, 139, 49, 81, 7, 237, 86, 62 }, new byte[] { 112, 114, 220, 25, 135, 245, 82, 72, 78, 91, 53, 40, 120, 210, 29, 254, 168, 243, 69, 148, 91, 18, 54, 41, 231, 167, 237, 37, 171, 117, 119, 253, 8, 219, 238, 222, 21, 10, 23, 33, 11, 95, 135, 5, 104, 223, 54, 77, 147, 59, 104, 194, 247, 138, 242, 28, 144, 102, 223, 103, 68, 99, 174, 73, 82, 240, 9, 251, 121, 103, 16, 6, 252, 169, 154, 217, 29, 236, 19, 213, 119, 231, 8, 188, 102, 229, 106, 186, 61, 185, 96, 68, 123, 181, 204, 64, 152, 18, 85, 201, 83, 70, 153, 142, 55, 248, 196, 66, 170, 62, 63, 204, 40, 183, 154, 19, 123, 114, 8, 130, 224, 54, 20, 33, 60, 171, 236, 211 } });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_GrauParentescoId",
                table: "ResponsaveisPacientes",
                column: "GrauParentescoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResponsaveisPacientes_GrauParentescoId",
                table: "ResponsaveisPacientes");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 9, 18, 18, 47, 16, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 117, 136, 208, 38, 39, 54, 162, 91, 98, 119, 242, 10, 238, 173, 145, 80, 141, 121, 24, 97, 72, 61, 27, 159, 255, 14, 151, 218, 192, 86, 109, 179, 96, 207, 145, 119, 60, 76, 254, 255, 97, 179, 137, 217, 243, 255, 187, 249, 9, 58, 200, 167, 150, 200, 190, 181, 98, 190, 211, 191, 167, 254, 255, 193 }, new byte[] { 117, 75, 143, 21, 82, 76, 205, 172, 116, 239, 132, 33, 172, 173, 151, 214, 136, 57, 196, 79, 152, 27, 182, 227, 219, 148, 122, 169, 0, 14, 173, 165, 144, 230, 212, 56, 139, 201, 73, 45, 170, 155, 82, 152, 192, 231, 95, 102, 160, 159, 61, 101, 5, 149, 188, 115, 72, 178, 164, 5, 94, 30, 45, 207, 101, 121, 122, 66, 182, 205, 1, 211, 80, 60, 229, 176, 195, 233, 75, 152, 204, 100, 83, 20, 149, 31, 49, 156, 125, 26, 185, 234, 55, 151, 64, 183, 166, 230, 194, 128, 189, 173, 55, 98, 161, 238, 129, 115, 240, 248, 56, 78, 94, 56, 166, 40, 107, 208, 223, 129, 72, 100, 204, 149, 170, 204, 73, 43 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 117, 136, 208, 38, 39, 54, 162, 91, 98, 119, 242, 10, 238, 173, 145, 80, 141, 121, 24, 97, 72, 61, 27, 159, 255, 14, 151, 218, 192, 86, 109, 179, 96, 207, 145, 119, 60, 76, 254, 255, 97, 179, 137, 217, 243, 255, 187, 249, 9, 58, 200, 167, 150, 200, 190, 181, 98, 190, 211, 191, 167, 254, 255, 193 }, new byte[] { 117, 75, 143, 21, 82, 76, 205, 172, 116, 239, 132, 33, 172, 173, 151, 214, 136, 57, 196, 79, 152, 27, 182, 227, 219, 148, 122, 169, 0, 14, 173, 165, 144, 230, 212, 56, 139, 201, 73, 45, 170, 155, 82, 152, 192, 231, 95, 102, 160, 159, 61, 101, 5, 149, 188, 115, 72, 178, 164, 5, 94, 30, 45, 207, 101, 121, 122, 66, 182, 205, 1, 211, 80, 60, 229, 176, 195, 233, 75, 152, 204, 100, 83, 20, 149, 31, 49, 156, 125, 26, 185, 234, 55, 151, 64, 183, 166, 230, 194, 128, 189, 173, 55, 98, 161, 238, 129, 115, 240, 248, 56, 78, 94, 56, 166, 40, 107, 208, 223, 129, 72, 100, 204, 149, 170, 204, 73, 43 } });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_GrauParentescoId",
                table: "ResponsaveisPacientes",
                column: "GrauParentescoId",
                unique: true);
        }
    }
}
