﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class RetirandoIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 22, 19, 23, 15, 35, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 63, 182, 23, 104, 55, 11, 93, 229, 92, 90, 146, 186, 155, 94, 136, 239, 0, 59, 236, 189, 26, 26, 56, 217, 191, 133, 221, 40, 242, 191, 242, 207, 154, 13, 210, 32, 74, 85, 97, 134, 192, 188, 79, 64, 39, 204, 140, 219, 249, 1, 171, 2, 141, 33, 58, 177, 77, 27, 241, 198, 155, 67, 70 }, new byte[] { 131, 85, 110, 182, 214, 117, 105, 118, 159, 200, 106, 136, 4, 149, 229, 208, 101, 53, 111, 35, 196, 32, 95, 127, 33, 109, 78, 210, 131, 9, 105, 122, 157, 66, 20, 207, 136, 175, 184, 102, 97, 74, 79, 125, 213, 251, 168, 114, 90, 31, 89, 141, 206, 72, 70, 83, 27, 77, 170, 32, 189, 123, 212, 6, 10, 168, 227, 50, 105, 200, 77, 121, 253, 36, 219, 74, 119, 112, 169, 22, 243, 223, 108, 90, 131, 181, 70, 44, 37, 19, 31, 53, 197, 209, 109, 230, 199, 214, 238, 219, 132, 14, 58, 204, 251, 19, 31, 2, 168, 46, 3, 211, 50, 82, 103, 190, 146, 86, 181, 33, 143, 59, 116, 73, 186, 207, 147, 64 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 63, 182, 23, 104, 55, 11, 93, 229, 92, 90, 146, 186, 155, 94, 136, 239, 0, 59, 236, 189, 26, 26, 56, 217, 191, 133, 221, 40, 242, 191, 242, 207, 154, 13, 210, 32, 74, 85, 97, 134, 192, 188, 79, 64, 39, 204, 140, 219, 249, 1, 171, 2, 141, 33, 58, 177, 77, 27, 241, 198, 155, 67, 70 }, new byte[] { 131, 85, 110, 182, 214, 117, 105, 118, 159, 200, 106, 136, 4, 149, 229, 208, 101, 53, 111, 35, 196, 32, 95, 127, 33, 109, 78, 210, 131, 9, 105, 122, 157, 66, 20, 207, 136, 175, 184, 102, 97, 74, 79, 125, 213, 251, 168, 114, 90, 31, 89, 141, 206, 72, 70, 83, 27, 77, 170, 32, 189, 123, 212, 6, 10, 168, 227, 50, 105, 200, 77, 121, 253, 36, 219, 74, 119, 112, 169, 22, 243, 223, 108, 90, 131, 181, 70, 44, 37, 19, 31, 53, 197, 209, 109, 230, 199, 214, 238, 219, 132, 14, 58, 204, 251, 19, 31, 2, 168, 46, 3, 211, 50, 82, 103, 190, 146, 86, 181, 33, 143, 59, 116, 73, 186, 207, 147, 64 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 63, 182, 23, 104, 55, 11, 93, 229, 92, 90, 146, 186, 155, 94, 136, 239, 0, 59, 236, 189, 26, 26, 56, 217, 191, 133, 221, 40, 242, 191, 242, 207, 154, 13, 210, 32, 74, 85, 97, 134, 192, 188, 79, 64, 39, 204, 140, 219, 249, 1, 171, 2, 141, 33, 58, 177, 77, 27, 241, 198, 155, 67, 70 }, new byte[] { 131, 85, 110, 182, 214, 117, 105, 118, 159, 200, 106, 136, 4, 149, 229, 208, 101, 53, 111, 35, 196, 32, 95, 127, 33, 109, 78, 210, 131, 9, 105, 122, 157, 66, 20, 207, 136, 175, 184, 102, 97, 74, 79, 125, 213, 251, 168, 114, 90, 31, 89, 141, 206, 72, 70, 83, 27, 77, 170, 32, 189, 123, 212, 6, 10, 168, 227, 50, 105, 200, 77, 121, 253, 36, 219, 74, 119, 112, 169, 22, 243, 223, 108, 90, 131, 181, 70, 44, 37, 19, 31, 53, 197, 209, 109, 230, 199, 214, 238, 219, 132, 14, 58, 204, 251, 19, 31, 2, 168, 46, 3, 211, 50, 82, 103, 190, 146, 86, 181, 33, 143, 59, 116, 73, 186, 207, 147, 64 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 63, 182, 23, 104, 55, 11, 93, 229, 92, 90, 146, 186, 155, 94, 136, 239, 0, 59, 236, 189, 26, 26, 56, 217, 191, 133, 221, 40, 242, 191, 242, 207, 154, 13, 210, 32, 74, 85, 97, 134, 192, 188, 79, 64, 39, 204, 140, 219, 249, 1, 171, 2, 141, 33, 58, 177, 77, 27, 241, 198, 155, 67, 70 }, new byte[] { 131, 85, 110, 182, 214, 117, 105, 118, 159, 200, 106, 136, 4, 149, 229, 208, 101, 53, 111, 35, 196, 32, 95, 127, 33, 109, 78, 210, 131, 9, 105, 122, 157, 66, 20, 207, 136, 175, 184, 102, 97, 74, 79, 125, 213, 251, 168, 114, 90, 31, 89, 141, 206, 72, 70, 83, 27, 77, 170, 32, 189, 123, 212, 6, 10, 168, 227, 50, 105, 200, 77, 121, 253, 36, 219, 74, 119, 112, 169, 22, 243, 223, 108, 90, 131, 181, 70, 44, 37, 19, 31, 53, 197, 209, 109, 230, 199, 214, 238, 219, 132, 14, 58, 204, 251, 19, 31, 2, 168, 46, 3, 211, 50, 82, 103, 190, 146, 86, 181, 33, 143, 59, 116, 73, 186, 207, 147, 64 } });

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoMedicacoes_PrescricaoPacienteId",
                table: "AndamentoMedicacoes",
                column: "PrescricaoPacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AndamentoMedicacoes_PrescricaoPacienteId",
                table: "AndamentoMedicacoes");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 22, 17, 10, 2, 533, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 130, 166, 16, 93, 213, 177, 100, 41, 126, 130, 103, 20, 45, 172, 212, 134, 97, 86, 30, 6, 162, 8, 32, 162, 122, 168, 196, 24, 155, 117, 88, 36, 16, 158, 238, 222, 243, 171, 127, 108, 169, 214, 64, 121, 187, 30, 209, 180, 211, 107, 51, 197, 127, 195, 58, 158, 123, 148, 199, 233, 109, 248, 234, 243 }, new byte[] { 37, 123, 161, 221, 245, 226, 112, 19, 65, 137, 15, 153, 16, 184, 72, 30, 142, 197, 83, 2, 70, 247, 117, 57, 27, 40, 169, 38, 79, 179, 231, 2, 214, 18, 191, 222, 90, 241, 68, 8, 41, 176, 254, 237, 68, 223, 175, 54, 86, 16, 251, 171, 174, 139, 202, 219, 85, 84, 8, 35, 111, 250, 104, 231, 28, 158, 200, 217, 210, 41, 26, 77, 232, 122, 51, 147, 147, 188, 72, 19, 97, 85, 65, 93, 242, 35, 119, 201, 251, 166, 113, 196, 96, 7, 225, 30, 60, 252, 119, 166, 220, 150, 223, 152, 59, 147, 186, 251, 243, 85, 45, 229, 175, 255, 171, 143, 33, 205, 245, 56, 181, 214, 222, 140, 178, 192, 88, 47 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 130, 166, 16, 93, 213, 177, 100, 41, 126, 130, 103, 20, 45, 172, 212, 134, 97, 86, 30, 6, 162, 8, 32, 162, 122, 168, 196, 24, 155, 117, 88, 36, 16, 158, 238, 222, 243, 171, 127, 108, 169, 214, 64, 121, 187, 30, 209, 180, 211, 107, 51, 197, 127, 195, 58, 158, 123, 148, 199, 233, 109, 248, 234, 243 }, new byte[] { 37, 123, 161, 221, 245, 226, 112, 19, 65, 137, 15, 153, 16, 184, 72, 30, 142, 197, 83, 2, 70, 247, 117, 57, 27, 40, 169, 38, 79, 179, 231, 2, 214, 18, 191, 222, 90, 241, 68, 8, 41, 176, 254, 237, 68, 223, 175, 54, 86, 16, 251, 171, 174, 139, 202, 219, 85, 84, 8, 35, 111, 250, 104, 231, 28, 158, 200, 217, 210, 41, 26, 77, 232, 122, 51, 147, 147, 188, 72, 19, 97, 85, 65, 93, 242, 35, 119, 201, 251, 166, 113, 196, 96, 7, 225, 30, 60, 252, 119, 166, 220, 150, 223, 152, 59, 147, 186, 251, 243, 85, 45, 229, 175, 255, 171, 143, 33, 205, 245, 56, 181, 214, 222, 140, 178, 192, 88, 47 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 130, 166, 16, 93, 213, 177, 100, 41, 126, 130, 103, 20, 45, 172, 212, 134, 97, 86, 30, 6, 162, 8, 32, 162, 122, 168, 196, 24, 155, 117, 88, 36, 16, 158, 238, 222, 243, 171, 127, 108, 169, 214, 64, 121, 187, 30, 209, 180, 211, 107, 51, 197, 127, 195, 58, 158, 123, 148, 199, 233, 109, 248, 234, 243 }, new byte[] { 37, 123, 161, 221, 245, 226, 112, 19, 65, 137, 15, 153, 16, 184, 72, 30, 142, 197, 83, 2, 70, 247, 117, 57, 27, 40, 169, 38, 79, 179, 231, 2, 214, 18, 191, 222, 90, 241, 68, 8, 41, 176, 254, 237, 68, 223, 175, 54, 86, 16, 251, 171, 174, 139, 202, 219, 85, 84, 8, 35, 111, 250, 104, 231, 28, 158, 200, 217, 210, 41, 26, 77, 232, 122, 51, 147, 147, 188, 72, 19, 97, 85, 65, 93, 242, 35, 119, 201, 251, 166, 113, 196, 96, 7, 225, 30, 60, 252, 119, 166, 220, 150, 223, 152, 59, 147, 186, 251, 243, 85, 45, 229, 175, 255, 171, 143, 33, 205, 245, 56, 181, 214, 222, 140, 178, 192, 88, 47 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 130, 166, 16, 93, 213, 177, 100, 41, 126, 130, 103, 20, 45, 172, 212, 134, 97, 86, 30, 6, 162, 8, 32, 162, 122, 168, 196, 24, 155, 117, 88, 36, 16, 158, 238, 222, 243, 171, 127, 108, 169, 214, 64, 121, 187, 30, 209, 180, 211, 107, 51, 197, 127, 195, 58, 158, 123, 148, 199, 233, 109, 248, 234, 243 }, new byte[] { 37, 123, 161, 221, 245, 226, 112, 19, 65, 137, 15, 153, 16, 184, 72, 30, 142, 197, 83, 2, 70, 247, 117, 57, 27, 40, 169, 38, 79, 179, 231, 2, 214, 18, 191, 222, 90, 241, 68, 8, 41, 176, 254, 237, 68, 223, 175, 54, 86, 16, 251, 171, 174, 139, 202, 219, 85, 84, 8, 35, 111, 250, 104, 231, 28, 158, 200, 217, 210, 41, 26, 77, 232, 122, 51, 147, 147, 188, 72, 19, 97, 85, 65, 93, 242, 35, 119, 201, 251, 166, 113, 196, 96, 7, 225, 30, 60, 252, 119, 166, 220, 150, 223, 152, 59, 147, 186, 251, 243, 85, 45, 229, 175, 255, 171, 143, 33, 205, 245, 56, 181, 214, 222, 140, 178, 192, 88, 47 } });
        }
    }
}