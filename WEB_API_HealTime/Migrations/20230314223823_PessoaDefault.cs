using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class PessoaDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "CpfPessoa", "DtNascPessoa", "NomePessoa", "PasswordHash", "PasswordSalt", "SobreNomePessoa", "TipoPessoaId" },
                values: new object[] { 1, "12345678909", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dan", new byte[] { 81, 42, 33, 218, 83, 126, 140, 104, 217, 193, 137, 248, 13, 163, 203, 135, 61, 252, 134, 69, 241, 118, 60, 201, 190, 42, 68, 52, 174, 183, 241, 84, 81, 119, 42, 171, 112, 166, 12, 125, 190, 194, 74, 143, 150, 252, 46, 73, 127, 41, 203, 31, 129, 74, 159, 90, 84, 240, 30, 215, 185, 0, 27, 63 }, new byte[] { 180, 29, 149, 236, 129, 225, 150, 168, 44, 157, 173, 88, 17, 152, 129, 21, 111, 186, 50, 99, 76, 24, 51, 141, 156, 108, 46, 97, 235, 237, 0, 236, 164, 210, 90, 143, 60, 65, 80, 157, 155, 74, 252, 244, 179, 86, 110, 66, 28, 115, 13, 12, 199, 48, 163, 151, 66, 23, 175, 72, 21, 130, 245, 201, 144, 71, 247, 242, 239, 227, 84, 130, 1, 236, 242, 211, 39, 171, 254, 117, 42, 128, 108, 217, 62, 4, 155, 150, 255, 5, 146, 15, 186, 109, 114, 34, 204, 179, 185, 161, 65, 133, 46, 16, 232, 84, 237, 22, 56, 113, 119, 49, 226, 149, 51, 115, 8, 137, 18, 250, 23, 200, 201, 168, 215, 100, 178, 94 }, "Marzo", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1);
        }
    }
}
