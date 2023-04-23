﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class retirandoNovoIndsex2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrescricoesMedicacoes_MedicacaoId",
                table: "PrescricoesMedicacoes");

            migrationBuilder.DropIndex(
                name: "IX_PrescricoesMedicacoes_PrescricaoMedicacaoId",
                table: "PrescricoesMedicacoes");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 22, 19, 32, 4, 607, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 9, 101, 37, 128, 229, 191, 223, 220, 161, 47, 67, 49, 238, 252, 255, 176, 102, 231, 217, 204, 235, 78, 45, 103, 137, 23, 238, 31, 232, 113, 63, 26, 0, 53, 8, 191, 170, 6, 241, 193, 250, 167, 86, 165, 216, 134, 201, 136, 179, 103, 211, 183, 222, 183, 136, 154, 17, 222, 165, 48, 67, 130, 114, 250 }, new byte[] { 248, 85, 206, 205, 36, 124, 251, 163, 138, 177, 74, 191, 124, 148, 223, 104, 158, 206, 42, 210, 77, 83, 59, 39, 51, 80, 64, 221, 6, 211, 240, 12, 124, 1, 84, 196, 4, 112, 195, 148, 55, 134, 73, 75, 102, 155, 181, 106, 110, 50, 49, 187, 231, 51, 195, 153, 54, 52, 25, 172, 146, 137, 204, 193, 82, 208, 230, 201, 109, 70, 188, 80, 149, 216, 20, 41, 140, 163, 21, 239, 87, 54, 105, 231, 69, 29, 91, 183, 193, 188, 37, 143, 224, 225, 179, 155, 163, 227, 113, 22, 174, 184, 245, 198, 148, 239, 75, 60, 251, 106, 51, 95, 243, 234, 119, 221, 115, 187, 126, 202, 32, 10, 142, 67, 187, 51, 9, 131 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 9, 101, 37, 128, 229, 191, 223, 220, 161, 47, 67, 49, 238, 252, 255, 176, 102, 231, 217, 204, 235, 78, 45, 103, 137, 23, 238, 31, 232, 113, 63, 26, 0, 53, 8, 191, 170, 6, 241, 193, 250, 167, 86, 165, 216, 134, 201, 136, 179, 103, 211, 183, 222, 183, 136, 154, 17, 222, 165, 48, 67, 130, 114, 250 }, new byte[] { 248, 85, 206, 205, 36, 124, 251, 163, 138, 177, 74, 191, 124, 148, 223, 104, 158, 206, 42, 210, 77, 83, 59, 39, 51, 80, 64, 221, 6, 211, 240, 12, 124, 1, 84, 196, 4, 112, 195, 148, 55, 134, 73, 75, 102, 155, 181, 106, 110, 50, 49, 187, 231, 51, 195, 153, 54, 52, 25, 172, 146, 137, 204, 193, 82, 208, 230, 201, 109, 70, 188, 80, 149, 216, 20, 41, 140, 163, 21, 239, 87, 54, 105, 231, 69, 29, 91, 183, 193, 188, 37, 143, 224, 225, 179, 155, 163, 227, 113, 22, 174, 184, 245, 198, 148, 239, 75, 60, 251, 106, 51, 95, 243, 234, 119, 221, 115, 187, 126, 202, 32, 10, 142, 67, 187, 51, 9, 131 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 9, 101, 37, 128, 229, 191, 223, 220, 161, 47, 67, 49, 238, 252, 255, 176, 102, 231, 217, 204, 235, 78, 45, 103, 137, 23, 238, 31, 232, 113, 63, 26, 0, 53, 8, 191, 170, 6, 241, 193, 250, 167, 86, 165, 216, 134, 201, 136, 179, 103, 211, 183, 222, 183, 136, 154, 17, 222, 165, 48, 67, 130, 114, 250 }, new byte[] { 248, 85, 206, 205, 36, 124, 251, 163, 138, 177, 74, 191, 124, 148, 223, 104, 158, 206, 42, 210, 77, 83, 59, 39, 51, 80, 64, 221, 6, 211, 240, 12, 124, 1, 84, 196, 4, 112, 195, 148, 55, 134, 73, 75, 102, 155, 181, 106, 110, 50, 49, 187, 231, 51, 195, 153, 54, 52, 25, 172, 146, 137, 204, 193, 82, 208, 230, 201, 109, 70, 188, 80, 149, 216, 20, 41, 140, 163, 21, 239, 87, 54, 105, 231, 69, 29, 91, 183, 193, 188, 37, 143, 224, 225, 179, 155, 163, 227, 113, 22, 174, 184, 245, 198, 148, 239, 75, 60, 251, 106, 51, 95, 243, 234, 119, 221, 115, 187, 126, 202, 32, 10, 142, 67, 187, 51, 9, 131 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 9, 101, 37, 128, 229, 191, 223, 220, 161, 47, 67, 49, 238, 252, 255, 176, 102, 231, 217, 204, 235, 78, 45, 103, 137, 23, 238, 31, 232, 113, 63, 26, 0, 53, 8, 191, 170, 6, 241, 193, 250, 167, 86, 165, 216, 134, 201, 136, 179, 103, 211, 183, 222, 183, 136, 154, 17, 222, 165, 48, 67, 130, 114, 250 }, new byte[] { 248, 85, 206, 205, 36, 124, 251, 163, 138, 177, 74, 191, 124, 148, 223, 104, 158, 206, 42, 210, 77, 83, 59, 39, 51, 80, 64, 221, 6, 211, 240, 12, 124, 1, 84, 196, 4, 112, 195, 148, 55, 134, 73, 75, 102, 155, 181, 106, 110, 50, 49, 187, 231, 51, 195, 153, 54, 52, 25, 172, 146, 137, 204, 193, 82, 208, 230, 201, 109, 70, 188, 80, 149, 216, 20, 41, 140, 163, 21, 239, 87, 54, 105, 231, 69, 29, 91, 183, 193, 188, 37, 143, 224, 225, 179, 155, 163, 227, 113, 22, 174, 184, 245, 198, 148, 239, 75, 60, 251, 106, 51, 95, 243, 234, 119, 221, 115, 187, 126, 202, 32, 10, 142, 67, 187, 51, 9, 131 } });

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicacoes_MedicacaoId",
                table: "PrescricoesMedicacoes",
                column: "MedicacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrescricoesMedicacoes_MedicacaoId",
                table: "PrescricoesMedicacoes");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 22, 19, 30, 2, 295, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 1, 186, 46, 241, 159, 54, 120, 160, 52, 13, 109, 90, 202, 222, 11, 18, 13, 81, 164, 131, 119, 210, 129, 124, 19, 232, 186, 133, 179, 218, 148, 252, 181, 228, 8, 35, 156, 49, 175, 69, 41, 248, 96, 199, 143, 78, 107, 214, 84, 225, 10, 179, 132, 184, 104, 78, 222, 193, 19, 117, 105, 163, 70, 43 }, new byte[] { 12, 56, 200, 235, 118, 122, 124, 217, 90, 66, 61, 118, 10, 235, 247, 225, 216, 28, 110, 36, 215, 112, 120, 229, 180, 55, 15, 116, 29, 195, 228, 214, 59, 110, 24, 249, 69, 121, 114, 39, 44, 13, 108, 83, 244, 215, 58, 158, 14, 111, 207, 73, 0, 220, 29, 238, 168, 199, 186, 143, 100, 88, 87, 85, 176, 81, 96, 174, 27, 113, 162, 158, 2, 20, 179, 151, 3, 105, 146, 38, 54, 199, 9, 224, 233, 111, 30, 70, 243, 130, 170, 74, 213, 71, 208, 124, 205, 106, 216, 81, 252, 192, 253, 237, 198, 73, 15, 200, 200, 14, 82, 193, 87, 240, 124, 73, 100, 228, 159, 187, 93, 81, 208, 242, 32, 48, 90, 131 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 1, 186, 46, 241, 159, 54, 120, 160, 52, 13, 109, 90, 202, 222, 11, 18, 13, 81, 164, 131, 119, 210, 129, 124, 19, 232, 186, 133, 179, 218, 148, 252, 181, 228, 8, 35, 156, 49, 175, 69, 41, 248, 96, 199, 143, 78, 107, 214, 84, 225, 10, 179, 132, 184, 104, 78, 222, 193, 19, 117, 105, 163, 70, 43 }, new byte[] { 12, 56, 200, 235, 118, 122, 124, 217, 90, 66, 61, 118, 10, 235, 247, 225, 216, 28, 110, 36, 215, 112, 120, 229, 180, 55, 15, 116, 29, 195, 228, 214, 59, 110, 24, 249, 69, 121, 114, 39, 44, 13, 108, 83, 244, 215, 58, 158, 14, 111, 207, 73, 0, 220, 29, 238, 168, 199, 186, 143, 100, 88, 87, 85, 176, 81, 96, 174, 27, 113, 162, 158, 2, 20, 179, 151, 3, 105, 146, 38, 54, 199, 9, 224, 233, 111, 30, 70, 243, 130, 170, 74, 213, 71, 208, 124, 205, 106, 216, 81, 252, 192, 253, 237, 198, 73, 15, 200, 200, 14, 82, 193, 87, 240, 124, 73, 100, 228, 159, 187, 93, 81, 208, 242, 32, 48, 90, 131 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 1, 186, 46, 241, 159, 54, 120, 160, 52, 13, 109, 90, 202, 222, 11, 18, 13, 81, 164, 131, 119, 210, 129, 124, 19, 232, 186, 133, 179, 218, 148, 252, 181, 228, 8, 35, 156, 49, 175, 69, 41, 248, 96, 199, 143, 78, 107, 214, 84, 225, 10, 179, 132, 184, 104, 78, 222, 193, 19, 117, 105, 163, 70, 43 }, new byte[] { 12, 56, 200, 235, 118, 122, 124, 217, 90, 66, 61, 118, 10, 235, 247, 225, 216, 28, 110, 36, 215, 112, 120, 229, 180, 55, 15, 116, 29, 195, 228, 214, 59, 110, 24, 249, 69, 121, 114, 39, 44, 13, 108, 83, 244, 215, 58, 158, 14, 111, 207, 73, 0, 220, 29, 238, 168, 199, 186, 143, 100, 88, 87, 85, 176, 81, 96, 174, 27, 113, 162, 158, 2, 20, 179, 151, 3, 105, 146, 38, 54, 199, 9, 224, 233, 111, 30, 70, 243, 130, 170, 74, 213, 71, 208, 124, 205, 106, 216, 81, 252, 192, 253, 237, 198, 73, 15, 200, 200, 14, 82, 193, 87, 240, 124, 73, 100, 228, 159, 187, 93, 81, 208, 242, 32, 48, 90, 131 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 1, 186, 46, 241, 159, 54, 120, 160, 52, 13, 109, 90, 202, 222, 11, 18, 13, 81, 164, 131, 119, 210, 129, 124, 19, 232, 186, 133, 179, 218, 148, 252, 181, 228, 8, 35, 156, 49, 175, 69, 41, 248, 96, 199, 143, 78, 107, 214, 84, 225, 10, 179, 132, 184, 104, 78, 222, 193, 19, 117, 105, 163, 70, 43 }, new byte[] { 12, 56, 200, 235, 118, 122, 124, 217, 90, 66, 61, 118, 10, 235, 247, 225, 216, 28, 110, 36, 215, 112, 120, 229, 180, 55, 15, 116, 29, 195, 228, 214, 59, 110, 24, 249, 69, 121, 114, 39, 44, 13, 108, 83, 244, 215, 58, 158, 14, 111, 207, 73, 0, 220, 29, 238, 168, 199, 186, 143, 100, 88, 87, 85, 176, 81, 96, 174, 27, 113, 162, 158, 2, 20, 179, 151, 3, 105, 146, 38, 54, 199, 9, 224, 233, 111, 30, 70, 243, 130, 170, 74, 213, 71, 208, 124, 205, 106, 216, 81, 252, 192, 253, 237, 198, 73, 15, 200, 200, 14, 82, 193, 87, 240, 124, 73, 100, 228, 159, 187, 93, 81, 208, 242, 32, 48, 90, 131 } });

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicacoes_MedicacaoId",
                table: "PrescricoesMedicacoes",
                column: "MedicacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicacoes_PrescricaoMedicacaoId",
                table: "PrescricoesMedicacoes",
                column: "PrescricaoMedicacaoId");
        }
    }
}
