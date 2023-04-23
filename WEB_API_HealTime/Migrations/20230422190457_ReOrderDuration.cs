﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class ReOrderDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duracao",
                table: "PrescricoesMedicacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 22, 16, 4, 57, 613, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 224, 21, 163, 34, 91, 55, 74, 196, 213, 9, 16, 71, 187, 182, 179, 88, 188, 237, 91, 194, 46, 97, 12, 90, 131, 28, 80, 178, 105, 13, 237, 6, 246, 24, 95, 189, 139, 215, 227, 220, 15, 221, 75, 204, 191, 192, 99, 158, 123, 56, 80, 195, 178, 60, 244, 161, 41, 54, 6, 200, 47, 19, 177, 42 }, new byte[] { 143, 254, 217, 245, 147, 129, 157, 15, 189, 188, 188, 90, 44, 196, 63, 78, 110, 176, 159, 70, 210, 47, 83, 21, 40, 222, 57, 243, 72, 50, 80, 67, 114, 83, 173, 135, 5, 213, 239, 38, 171, 89, 61, 86, 43, 106, 231, 153, 30, 139, 85, 13, 82, 78, 253, 33, 46, 11, 237, 36, 40, 239, 213, 163, 140, 44, 56, 239, 238, 21, 182, 163, 142, 190, 24, 102, 177, 58, 235, 110, 202, 247, 142, 197, 36, 234, 38, 230, 42, 0, 180, 178, 201, 54, 14, 65, 11, 31, 175, 186, 229, 137, 58, 47, 209, 163, 252, 148, 190, 52, 228, 95, 4, 125, 199, 219, 63, 227, 93, 19, 179, 9, 194, 75, 23, 133, 103, 252 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 224, 21, 163, 34, 91, 55, 74, 196, 213, 9, 16, 71, 187, 182, 179, 88, 188, 237, 91, 194, 46, 97, 12, 90, 131, 28, 80, 178, 105, 13, 237, 6, 246, 24, 95, 189, 139, 215, 227, 220, 15, 221, 75, 204, 191, 192, 99, 158, 123, 56, 80, 195, 178, 60, 244, 161, 41, 54, 6, 200, 47, 19, 177, 42 }, new byte[] { 143, 254, 217, 245, 147, 129, 157, 15, 189, 188, 188, 90, 44, 196, 63, 78, 110, 176, 159, 70, 210, 47, 83, 21, 40, 222, 57, 243, 72, 50, 80, 67, 114, 83, 173, 135, 5, 213, 239, 38, 171, 89, 61, 86, 43, 106, 231, 153, 30, 139, 85, 13, 82, 78, 253, 33, 46, 11, 237, 36, 40, 239, 213, 163, 140, 44, 56, 239, 238, 21, 182, 163, 142, 190, 24, 102, 177, 58, 235, 110, 202, 247, 142, 197, 36, 234, 38, 230, 42, 0, 180, 178, 201, 54, 14, 65, 11, 31, 175, 186, 229, 137, 58, 47, 209, 163, 252, 148, 190, 52, 228, 95, 4, 125, 199, 219, 63, 227, 93, 19, 179, 9, 194, 75, 23, 133, 103, 252 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 224, 21, 163, 34, 91, 55, 74, 196, 213, 9, 16, 71, 187, 182, 179, 88, 188, 237, 91, 194, 46, 97, 12, 90, 131, 28, 80, 178, 105, 13, 237, 6, 246, 24, 95, 189, 139, 215, 227, 220, 15, 221, 75, 204, 191, 192, 99, 158, 123, 56, 80, 195, 178, 60, 244, 161, 41, 54, 6, 200, 47, 19, 177, 42 }, new byte[] { 143, 254, 217, 245, 147, 129, 157, 15, 189, 188, 188, 90, 44, 196, 63, 78, 110, 176, 159, 70, 210, 47, 83, 21, 40, 222, 57, 243, 72, 50, 80, 67, 114, 83, 173, 135, 5, 213, 239, 38, 171, 89, 61, 86, 43, 106, 231, 153, 30, 139, 85, 13, 82, 78, 253, 33, 46, 11, 237, 36, 40, 239, 213, 163, 140, 44, 56, 239, 238, 21, 182, 163, 142, 190, 24, 102, 177, 58, 235, 110, 202, 247, 142, 197, 36, 234, 38, 230, 42, 0, 180, 178, 201, 54, 14, 65, 11, 31, 175, 186, 229, 137, 58, 47, 209, 163, 252, 148, 190, 52, 228, 95, 4, 125, 199, 219, 63, 227, 93, 19, 179, 9, 194, 75, 23, 133, 103, 252 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 224, 21, 163, 34, 91, 55, 74, 196, 213, 9, 16, 71, 187, 182, 179, 88, 188, 237, 91, 194, 46, 97, 12, 90, 131, 28, 80, 178, 105, 13, 237, 6, 246, 24, 95, 189, 139, 215, 227, 220, 15, 221, 75, 204, 191, 192, 99, 158, 123, 56, 80, 195, 178, 60, 244, 161, 41, 54, 6, 200, 47, 19, 177, 42 }, new byte[] { 143, 254, 217, 245, 147, 129, 157, 15, 189, 188, 188, 90, 44, 196, 63, 78, 110, 176, 159, 70, 210, 47, 83, 21, 40, 222, 57, 243, 72, 50, 80, 67, 114, 83, 173, 135, 5, 213, 239, 38, 171, 89, 61, 86, 43, 106, 231, 153, 30, 139, 85, 13, 82, 78, 253, 33, 46, 11, 237, 36, 40, 239, 213, 163, 140, 44, 56, 239, 238, 21, 182, 163, 142, 190, 24, 102, 177, 58, 235, 110, 202, 247, 142, 197, 36, 234, 38, 230, 42, 0, 180, 178, 201, 54, 14, 65, 11, 31, 175, 186, 229, 137, 58, 47, 209, 163, 252, 148, 190, 52, 228, 95, 4, 125, 199, 219, 63, 227, 93, 19, 179, 9, 194, 75, 23, 133, 103, 252 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Duracao",
                table: "PrescricoesMedicacoes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 18, 20, 51, 19, 925, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 61, 223, 74, 44, 88, 233, 131, 140, 180, 242, 167, 202, 181, 73, 172, 50, 22, 89, 250, 245, 48, 5, 28, 247, 200, 183, 190, 243, 82, 122, 131, 72, 178, 81, 201, 214, 155, 72, 109, 5, 115, 106, 177, 237, 24, 123, 112, 247, 157, 99, 185, 155, 222, 137, 61, 207, 80, 1, 255, 248, 36, 241, 92 }, new byte[] { 249, 164, 4, 52, 133, 150, 145, 49, 77, 210, 35, 220, 248, 37, 244, 61, 74, 200, 3, 153, 2, 50, 21, 227, 211, 34, 65, 39, 205, 17, 68, 33, 166, 105, 1, 254, 152, 88, 207, 62, 31, 84, 209, 247, 190, 88, 96, 217, 34, 54, 229, 113, 143, 148, 97, 126, 217, 218, 232, 209, 26, 231, 92, 7, 65, 238, 210, 112, 166, 198, 26, 114, 11, 31, 234, 131, 75, 228, 232, 226, 118, 29, 232, 42, 114, 235, 39, 222, 129, 155, 211, 79, 1, 2, 229, 149, 2, 240, 12, 32, 227, 119, 65, 84, 16, 63, 123, 167, 194, 60, 116, 33, 115, 135, 183, 145, 87, 193, 206, 70, 54, 72, 239, 91, 17, 59, 28, 113 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 61, 223, 74, 44, 88, 233, 131, 140, 180, 242, 167, 202, 181, 73, 172, 50, 22, 89, 250, 245, 48, 5, 28, 247, 200, 183, 190, 243, 82, 122, 131, 72, 178, 81, 201, 214, 155, 72, 109, 5, 115, 106, 177, 237, 24, 123, 112, 247, 157, 99, 185, 155, 222, 137, 61, 207, 80, 1, 255, 248, 36, 241, 92 }, new byte[] { 249, 164, 4, 52, 133, 150, 145, 49, 77, 210, 35, 220, 248, 37, 244, 61, 74, 200, 3, 153, 2, 50, 21, 227, 211, 34, 65, 39, 205, 17, 68, 33, 166, 105, 1, 254, 152, 88, 207, 62, 31, 84, 209, 247, 190, 88, 96, 217, 34, 54, 229, 113, 143, 148, 97, 126, 217, 218, 232, 209, 26, 231, 92, 7, 65, 238, 210, 112, 166, 198, 26, 114, 11, 31, 234, 131, 75, 228, 232, 226, 118, 29, 232, 42, 114, 235, 39, 222, 129, 155, 211, 79, 1, 2, 229, 149, 2, 240, 12, 32, 227, 119, 65, 84, 16, 63, 123, 167, 194, 60, 116, 33, 115, 135, 183, 145, 87, 193, 206, 70, 54, 72, 239, 91, 17, 59, 28, 113 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 61, 223, 74, 44, 88, 233, 131, 140, 180, 242, 167, 202, 181, 73, 172, 50, 22, 89, 250, 245, 48, 5, 28, 247, 200, 183, 190, 243, 82, 122, 131, 72, 178, 81, 201, 214, 155, 72, 109, 5, 115, 106, 177, 237, 24, 123, 112, 247, 157, 99, 185, 155, 222, 137, 61, 207, 80, 1, 255, 248, 36, 241, 92 }, new byte[] { 249, 164, 4, 52, 133, 150, 145, 49, 77, 210, 35, 220, 248, 37, 244, 61, 74, 200, 3, 153, 2, 50, 21, 227, 211, 34, 65, 39, 205, 17, 68, 33, 166, 105, 1, 254, 152, 88, 207, 62, 31, 84, 209, 247, 190, 88, 96, 217, 34, 54, 229, 113, 143, 148, 97, 126, 217, 218, 232, 209, 26, 231, 92, 7, 65, 238, 210, 112, 166, 198, 26, 114, 11, 31, 234, 131, 75, 228, 232, 226, 118, 29, 232, 42, 114, 235, 39, 222, 129, 155, 211, 79, 1, 2, 229, 149, 2, 240, 12, 32, 227, 119, 65, 84, 16, 63, 123, 167, 194, 60, 116, 33, 115, 135, 183, 145, 87, 193, 206, 70, 54, 72, 239, 91, 17, 59, 28, 113 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 61, 223, 74, 44, 88, 233, 131, 140, 180, 242, 167, 202, 181, 73, 172, 50, 22, 89, 250, 245, 48, 5, 28, 247, 200, 183, 190, 243, 82, 122, 131, 72, 178, 81, 201, 214, 155, 72, 109, 5, 115, 106, 177, 237, 24, 123, 112, 247, 157, 99, 185, 155, 222, 137, 61, 207, 80, 1, 255, 248, 36, 241, 92 }, new byte[] { 249, 164, 4, 52, 133, 150, 145, 49, 77, 210, 35, 220, 248, 37, 244, 61, 74, 200, 3, 153, 2, 50, 21, 227, 211, 34, 65, 39, 205, 17, 68, 33, 166, 105, 1, 254, 152, 88, 207, 62, 31, 84, 209, 247, 190, 88, 96, 217, 34, 54, 229, 113, 143, 148, 97, 126, 217, 218, 232, 209, 26, 231, 92, 7, 65, 238, 210, 112, 166, 198, 26, 114, 11, 31, 234, 131, 75, 228, 232, 226, 118, 29, 232, 42, 114, 235, 39, 222, 129, 155, 211, 79, 1, 2, 229, 149, 2, 240, 12, 32, 227, 119, 65, 84, 16, 63, 123, 167, 194, 60, 116, 33, 115, 135, 183, 145, 87, 193, 206, 70, 54, 72, 239, 91, 17, 59, 28, 113 } });
        }
    }
}