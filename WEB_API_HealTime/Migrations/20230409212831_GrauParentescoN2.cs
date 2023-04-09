﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class GrauParentescoN2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResponsaveisPacientes_PacienteId",
                table: "ResponsaveisPacientes");

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
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 12, 80, 192, 245, 161, 117, 152, 81, 21, 21, 186, 202, 240, 113, 63, 110, 252, 34, 245, 7, 66, 139, 11, 142, 193, 199, 14, 3, 83, 100, 228, 55, 211, 219, 180, 173, 245, 243, 161, 199, 29, 254, 212, 55, 7, 138, 146, 88, 221, 19, 161, 88, 184, 94, 98, 19, 47, 155, 73, 167, 166, 132, 137 }, new byte[] { 102, 112, 194, 33, 71, 23, 200, 99, 233, 199, 226, 96, 10, 49, 194, 134, 84, 213, 239, 145, 246, 12, 193, 65, 197, 17, 150, 52, 164, 79, 39, 88, 195, 222, 198, 170, 235, 120, 0, 204, 174, 13, 224, 145, 155, 157, 218, 30, 158, 125, 134, 109, 88, 230, 144, 49, 120, 194, 156, 244, 180, 112, 247, 231, 236, 79, 52, 220, 205, 194, 9, 51, 178, 231, 109, 61, 145, 211, 44, 108, 210, 8, 143, 159, 248, 218, 45, 227, 3, 213, 123, 4, 245, 20, 141, 86, 120, 167, 225, 234, 182, 114, 175, 230, 3, 66, 61, 75, 68, 68, 0, 238, 58, 139, 30, 138, 72, 68, 233, 113, 155, 254, 107, 199, 48, 2, 254, 17 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 12, 80, 192, 245, 161, 117, 152, 81, 21, 21, 186, 202, 240, 113, 63, 110, 252, 34, 245, 7, 66, 139, 11, 142, 193, 199, 14, 3, 83, 100, 228, 55, 211, 219, 180, 173, 245, 243, 161, 199, 29, 254, 212, 55, 7, 138, 146, 88, 221, 19, 161, 88, 184, 94, 98, 19, 47, 155, 73, 167, 166, 132, 137 }, new byte[] { 102, 112, 194, 33, 71, 23, 200, 99, 233, 199, 226, 96, 10, 49, 194, 134, 84, 213, 239, 145, 246, 12, 193, 65, 197, 17, 150, 52, 164, 79, 39, 88, 195, 222, 198, 170, 235, 120, 0, 204, 174, 13, 224, 145, 155, 157, 218, 30, 158, 125, 134, 109, 88, 230, 144, 49, 120, 194, 156, 244, 180, 112, 247, 231, 236, 79, 52, 220, 205, 194, 9, 51, 178, 231, 109, 61, 145, 211, 44, 108, 210, 8, 143, 159, 248, 218, 45, 227, 3, 213, 123, 4, 245, 20, 141, 86, 120, 167, 225, 234, 182, 114, 175, 230, 3, 66, 61, 75, 68, 68, 0, 238, 58, 139, 30, 138, 72, 68, 233, 113, 155, 254, 107, 199, 48, 2, 254, 17 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_ResponsaveisPacientes_PacienteId",
                table: "ResponsaveisPacientes",
                column: "PacienteId",
                unique: true);
        }
    }
}
