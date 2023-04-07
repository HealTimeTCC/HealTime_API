using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurandoIndexNoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 6, 23, 0, 51, 876, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "CpfPessoa", "PasswordHash", "PasswordSalt" },
                values: new object[] { "67146867064", new byte[] { 50, 98, 169, 16, 36, 8, 146, 18, 76, 82, 219, 106, 72, 245, 7, 179, 191, 240, 45, 92, 187, 46, 233, 201, 65, 182, 101, 254, 63, 16, 145, 219, 187, 73, 91, 19, 36, 68, 99, 219, 153, 231, 58, 19, 222, 22, 28, 150, 248, 77, 91, 47, 143, 34, 212, 217, 175, 48, 64, 206, 20, 179, 50, 132 }, new byte[] { 67, 137, 26, 205, 136, 169, 247, 135, 232, 182, 25, 228, 212, 65, 206, 199, 221, 55, 97, 133, 88, 30, 106, 10, 133, 226, 102, 47, 78, 18, 30, 139, 225, 93, 207, 63, 149, 155, 46, 121, 177, 108, 91, 211, 234, 93, 148, 221, 233, 250, 153, 81, 201, 182, 111, 121, 230, 72, 228, 150, 163, 239, 241, 177, 127, 104, 12, 77, 22, 205, 188, 250, 233, 169, 147, 5, 227, 189, 37, 187, 46, 60, 44, 164, 100, 38, 95, 105, 143, 52, 138, 181, 25, 245, 57, 255, 139, 88, 220, 252, 246, 10, 44, 176, 58, 50, 248, 39, 106, 220, 61, 26, 207, 112, 65, 107, 70, 210, 197, 102, 118, 124, 218, 13, 203, 153, 152, 35 } });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "CpfPessoa", "DtNascPessoa", "NomePessoa", "PasswordHash", "PasswordSalt", "SobreNomePessoa", "TipoPessoa" },
                values: new object[] { 2, "15063626050", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dan PACIENTE INCAPAZ", new byte[] { 50, 98, 169, 16, 36, 8, 146, 18, 76, 82, 219, 106, 72, 245, 7, 179, 191, 240, 45, 92, 187, 46, 233, 201, 65, 182, 101, 254, 63, 16, 145, 219, 187, 73, 91, 19, 36, 68, 99, 219, 153, 231, 58, 19, 222, 22, 28, 150, 248, 77, 91, 47, 143, 34, 212, 217, 175, 48, 64, 206, 20, 179, 50, 132 }, new byte[] { 67, 137, 26, 205, 136, 169, 247, 135, 232, 182, 25, 228, 212, 65, 206, 199, 221, 55, 97, 133, 88, 30, 106, 10, 133, 226, 102, 47, 78, 18, 30, 139, 225, 93, 207, 63, 149, 155, 46, 121, 177, 108, 91, 211, 234, 93, 148, 221, 233, 250, 153, 81, 201, 182, 111, 121, 230, 72, 228, 150, 163, 239, 241, 177, 127, 104, 12, 77, 22, 205, 188, 250, 233, 169, 147, 5, 227, 189, 37, 187, 46, 60, 44, 164, 100, 38, 95, 105, 143, 52, 138, 181, 25, 245, 57, 255, 139, 88, 220, 252, 246, 10, 44, 176, 58, 50, 248, 39, 106, 220, 61, 26, 207, 112, 65, 107, 70, 210, 197, 102, 118, 124, 218, 13, 203, 153, 152, 35 }, "Marzo", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CpfPessoa",
                table: "Pessoas",
                column: "CpfPessoa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CpfPessoa",
                table: "Pessoas");

            migrationBuilder.DeleteData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2);

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
                columns: new[] { "CpfPessoa", "PasswordHash", "PasswordSalt" },
                values: new object[] { "12345678909", new byte[] { 255, 20, 153, 105, 190, 113, 138, 3, 163, 173, 185, 234, 107, 92, 29, 2, 227, 118, 17, 191, 91, 213, 1, 204, 6, 24, 136, 228, 202, 47, 118, 199, 74, 225, 113, 11, 31, 5, 34, 81, 208, 91, 215, 78, 178, 104, 217, 94, 165, 129, 90, 209, 136, 158, 74, 71, 167, 129, 59, 205, 140, 240, 20, 205 }, new byte[] { 166, 215, 57, 46, 74, 84, 85, 34, 123, 235, 157, 95, 77, 188, 186, 100, 68, 110, 97, 27, 117, 128, 66, 4, 174, 70, 192, 156, 35, 98, 155, 117, 160, 108, 9, 46, 28, 182, 202, 112, 54, 112, 152, 140, 239, 91, 94, 252, 4, 244, 164, 215, 250, 230, 246, 38, 160, 141, 151, 205, 111, 246, 203, 155, 96, 225, 47, 224, 100, 215, 174, 97, 151, 55, 173, 243, 220, 5, 103, 187, 133, 254, 209, 101, 137, 182, 210, 65, 221, 167, 87, 84, 65, 112, 155, 151, 68, 63, 84, 110, 78, 179, 75, 209, 142, 0, 145, 251, 139, 31, 9, 230, 19, 231, 39, 190, 239, 249, 160, 211, 17, 78, 104, 187, 48, 96, 214, 209 } });
        }
    }
}
