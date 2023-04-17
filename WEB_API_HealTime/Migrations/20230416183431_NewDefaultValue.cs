using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class NewDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CuidadorPacientes_PacienteId_CuidadorId",
                table: "CuidadorPacientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuidadorPacientes_PacienteId_CuidadorId",
                table: "CuidadorPacientes",
                columns: new[] { "PacienteId", "CuidadorId", "CriadoEm" });

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 16, 15, 34, 30, 933, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "NomePessoa", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Responsavel", new byte[] { 86, 224, 138, 85, 206, 52, 38, 79, 208, 55, 57, 131, 127, 160, 111, 91, 77, 14, 196, 157, 68, 201, 37, 111, 199, 187, 136, 72, 87, 124, 34, 53, 51, 145, 216, 75, 240, 139, 86, 19, 32, 206, 53, 179, 186, 97, 5, 43, 20, 84, 126, 149, 109, 191, 175, 180, 206, 97, 242, 198, 120, 179, 189, 161 }, new byte[] { 189, 209, 45, 60, 111, 178, 46, 169, 105, 143, 214, 58, 205, 65, 190, 20, 147, 198, 64, 149, 113, 92, 108, 248, 233, 149, 220, 129, 30, 46, 185, 255, 72, 76, 235, 21, 103, 91, 80, 119, 184, 127, 13, 36, 53, 95, 14, 185, 234, 188, 195, 153, 224, 193, 156, 174, 23, 136, 62, 68, 65, 148, 174, 43, 218, 247, 106, 126, 26, 73, 30, 26, 79, 45, 235, 149, 23, 40, 203, 178, 112, 104, 254, 135, 25, 247, 81, 35, 217, 37, 240, 227, 4, 45, 58, 104, 141, 15, 2, 44, 227, 9, 234, 231, 203, 113, 140, 106, 125, 208, 143, 55, 197, 116, 8, 221, 253, 59, 134, 14, 15, 252, 95, 159, 227, 239, 143, 146 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "NomePessoa", "PasswordHash", "PasswordSalt" },
                values: new object[] { "PacienteIncapaz", new byte[] { 86, 224, 138, 85, 206, 52, 38, 79, 208, 55, 57, 131, 127, 160, 111, 91, 77, 14, 196, 157, 68, 201, 37, 111, 199, 187, 136, 72, 87, 124, 34, 53, 51, 145, 216, 75, 240, 139, 86, 19, 32, 206, 53, 179, 186, 97, 5, 43, 20, 84, 126, 149, 109, 191, 175, 180, 206, 97, 242, 198, 120, 179, 189, 161 }, new byte[] { 189, 209, 45, 60, 111, 178, 46, 169, 105, 143, 214, 58, 205, 65, 190, 20, 147, 198, 64, 149, 113, 92, 108, 248, 233, 149, 220, 129, 30, 46, 185, 255, 72, 76, 235, 21, 103, 91, 80, 119, 184, 127, 13, 36, 53, 95, 14, 185, 234, 188, 195, 153, 224, 193, 156, 174, 23, 136, 62, 68, 65, 148, 174, 43, 218, 247, 106, 126, 26, 73, 30, 26, 79, 45, 235, 149, 23, 40, 203, 178, 112, 104, 254, 135, 25, 247, 81, 35, 217, 37, 240, 227, 4, 45, 58, 104, 141, 15, 2, 44, 227, 9, 234, 231, 203, 113, 140, 106, 125, 208, 143, 55, 197, 116, 8, 221, 253, 59, 134, 14, 15, 252, 95, 159, 227, 239, 143, 146 } });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "CpfPessoa", "DtNascPessoa", "NomePessoa", "PasswordHash", "PasswordSalt", "SobreNomePessoa", "TipoPessoa" },
                values: new object[,]
                {
                    { 3, "94840911053", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuidador", new byte[] { 86, 224, 138, 85, 206, 52, 38, 79, 208, 55, 57, 131, 127, 160, 111, 91, 77, 14, 196, 157, 68, 201, 37, 111, 199, 187, 136, 72, 87, 124, 34, 53, 51, 145, 216, 75, 240, 139, 86, 19, 32, 206, 53, 179, 186, 97, 5, 43, 20, 84, 126, 149, 109, 191, 175, 180, 206, 97, 242, 198, 120, 179, 189, 161 }, new byte[] { 189, 209, 45, 60, 111, 178, 46, 169, 105, 143, 214, 58, 205, 65, 190, 20, 147, 198, 64, 149, 113, 92, 108, 248, 233, 149, 220, 129, 30, 46, 185, 255, 72, 76, 235, 21, 103, 91, 80, 119, 184, 127, 13, 36, 53, 95, 14, 185, 234, 188, 195, 153, 224, 193, 156, 174, 23, 136, 62, 68, 65, 148, 174, 43, 218, 247, 106, 126, 26, 73, 30, 26, 79, 45, 235, 149, 23, 40, 203, 178, 112, 104, 254, 135, 25, 247, 81, 35, 217, 37, 240, 227, 4, 45, 58, 104, 141, 15, 2, 44, 227, 9, 234, 231, 203, 113, 140, 106, 125, 208, 143, 55, 197, 116, 8, 221, 253, 59, 134, 14, 15, 252, 95, 159, 227, 239, 143, 146 }, "Marzo", 4 },
                    { 4, "50967422027", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paciente", new byte[] { 86, 224, 138, 85, 206, 52, 38, 79, 208, 55, 57, 131, 127, 160, 111, 91, 77, 14, 196, 157, 68, 201, 37, 111, 199, 187, 136, 72, 87, 124, 34, 53, 51, 145, 216, 75, 240, 139, 86, 19, 32, 206, 53, 179, 186, 97, 5, 43, 20, 84, 126, 149, 109, 191, 175, 180, 206, 97, 242, 198, 120, 179, 189, 161 }, new byte[] { 189, 209, 45, 60, 111, 178, 46, 169, 105, 143, 214, 58, 205, 65, 190, 20, 147, 198, 64, 149, 113, 92, 108, 248, 233, 149, 220, 129, 30, 46, 185, 255, 72, 76, 235, 21, 103, 91, 80, 119, 184, 127, 13, 36, 53, 95, 14, 185, 234, 188, 195, 153, 224, 193, 156, 174, 23, 136, 62, 68, 65, 148, 174, 43, 218, 247, 106, 126, 26, 73, 30, 26, 79, 45, 235, 149, 23, 40, 203, 178, 112, 104, 254, 135, 25, 247, 81, 35, 217, 37, 240, 227, 4, 45, 58, 104, 141, 15, 2, 44, 227, 9, 234, 231, 203, 113, 140, 106, 125, 208, 143, 55, 197, 116, 8, 221, 253, 59, 134, 14, 15, 252, 95, 159, 227, 239, 143, 146 }, "Marzo", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CuidadorPacientes_PacienteId_CuidadorId",
                table: "CuidadorPacientes");

            migrationBuilder.DeleteData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuidadorPacientes_PacienteId_CuidadorId",
                table: "CuidadorPacientes",
                columns: new[] { "PacienteId", "CuidadorId" });

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 9, 18, 28, 31, 162, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "NomePessoa", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Dan", new byte[] { 175, 12, 80, 192, 245, 161, 117, 152, 81, 21, 21, 186, 202, 240, 113, 63, 110, 252, 34, 245, 7, 66, 139, 11, 142, 193, 199, 14, 3, 83, 100, 228, 55, 211, 219, 180, 173, 245, 243, 161, 199, 29, 254, 212, 55, 7, 138, 146, 88, 221, 19, 161, 88, 184, 94, 98, 19, 47, 155, 73, 167, 166, 132, 137 }, new byte[] { 102, 112, 194, 33, 71, 23, 200, 99, 233, 199, 226, 96, 10, 49, 194, 134, 84, 213, 239, 145, 246, 12, 193, 65, 197, 17, 150, 52, 164, 79, 39, 88, 195, 222, 198, 170, 235, 120, 0, 204, 174, 13, 224, 145, 155, 157, 218, 30, 158, 125, 134, 109, 88, 230, 144, 49, 120, 194, 156, 244, 180, 112, 247, 231, 236, 79, 52, 220, 205, 194, 9, 51, 178, 231, 109, 61, 145, 211, 44, 108, 210, 8, 143, 159, 248, 218, 45, 227, 3, 213, 123, 4, 245, 20, 141, 86, 120, 167, 225, 234, 182, 114, 175, 230, 3, 66, 61, 75, 68, 68, 0, 238, 58, 139, 30, 138, 72, 68, 233, 113, 155, 254, 107, 199, 48, 2, 254, 17 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "NomePessoa", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Dan PACIENTE INCAPAZ", new byte[] { 175, 12, 80, 192, 245, 161, 117, 152, 81, 21, 21, 186, 202, 240, 113, 63, 110, 252, 34, 245, 7, 66, 139, 11, 142, 193, 199, 14, 3, 83, 100, 228, 55, 211, 219, 180, 173, 245, 243, 161, 199, 29, 254, 212, 55, 7, 138, 146, 88, 221, 19, 161, 88, 184, 94, 98, 19, 47, 155, 73, 167, 166, 132, 137 }, new byte[] { 102, 112, 194, 33, 71, 23, 200, 99, 233, 199, 226, 96, 10, 49, 194, 134, 84, 213, 239, 145, 246, 12, 193, 65, 197, 17, 150, 52, 164, 79, 39, 88, 195, 222, 198, 170, 235, 120, 0, 204, 174, 13, 224, 145, 155, 157, 218, 30, 158, 125, 134, 109, 88, 230, 144, 49, 120, 194, 156, 244, 180, 112, 247, 231, 236, 79, 52, 220, 205, 194, 9, 51, 178, 231, 109, 61, 145, 211, 44, 108, 210, 8, 143, 159, 248, 218, 45, 227, 3, 213, 123, 4, 245, 20, 141, 86, 120, 167, 225, 234, 182, 114, 175, 230, 3, 66, 61, 75, 68, 68, 0, 238, 58, 139, 30, 138, 72, 68, 233, 113, 155, 254, 107, 199, 48, 2, 254, 17 } });
        }
    }
}
