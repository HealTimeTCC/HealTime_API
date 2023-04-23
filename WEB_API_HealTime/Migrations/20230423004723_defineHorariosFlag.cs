﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class defineHorariosFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HorariosDefinidos",
                table: "PrescricoesMedicacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 4, 22, 21, 47, 23, 77, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 132, 197, 159, 47, 243, 237, 113, 136, 75, 36, 192, 50, 68, 153, 210, 132, 33, 197, 165, 103, 221, 182, 33, 159, 2, 184, 25, 107, 179, 215, 21, 241, 241, 181, 145, 186, 241, 19, 251, 170, 92, 183, 90, 203, 201, 186, 6, 81, 73, 130, 31, 144, 215, 219, 244, 14, 216, 20, 156, 246, 129, 246, 6, 39 }, new byte[] { 179, 214, 175, 178, 243, 250, 158, 30, 22, 103, 210, 225, 235, 165, 146, 28, 219, 75, 121, 229, 57, 53, 138, 65, 78, 184, 180, 133, 235, 216, 138, 44, 193, 136, 78, 229, 218, 125, 95, 219, 184, 123, 55, 79, 87, 107, 32, 181, 197, 4, 119, 9, 1, 171, 99, 144, 78, 30, 33, 206, 137, 56, 60, 234, 1, 107, 184, 51, 225, 141, 178, 235, 126, 162, 41, 243, 225, 200, 249, 92, 193, 132, 53, 186, 183, 242, 87, 83, 58, 218, 61, 22, 121, 190, 196, 42, 162, 164, 80, 182, 8, 140, 46, 32, 156, 89, 115, 84, 248, 190, 174, 161, 73, 240, 29, 6, 224, 99, 160, 251, 148, 18, 176, 202, 143, 100, 197, 188 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 132, 197, 159, 47, 243, 237, 113, 136, 75, 36, 192, 50, 68, 153, 210, 132, 33, 197, 165, 103, 221, 182, 33, 159, 2, 184, 25, 107, 179, 215, 21, 241, 241, 181, 145, 186, 241, 19, 251, 170, 92, 183, 90, 203, 201, 186, 6, 81, 73, 130, 31, 144, 215, 219, 244, 14, 216, 20, 156, 246, 129, 246, 6, 39 }, new byte[] { 179, 214, 175, 178, 243, 250, 158, 30, 22, 103, 210, 225, 235, 165, 146, 28, 219, 75, 121, 229, 57, 53, 138, 65, 78, 184, 180, 133, 235, 216, 138, 44, 193, 136, 78, 229, 218, 125, 95, 219, 184, 123, 55, 79, 87, 107, 32, 181, 197, 4, 119, 9, 1, 171, 99, 144, 78, 30, 33, 206, 137, 56, 60, 234, 1, 107, 184, 51, 225, 141, 178, 235, 126, 162, 41, 243, 225, 200, 249, 92, 193, 132, 53, 186, 183, 242, 87, 83, 58, 218, 61, 22, 121, 190, 196, 42, 162, 164, 80, 182, 8, 140, 46, 32, 156, 89, 115, 84, 248, 190, 174, 161, 73, 240, 29, 6, 224, 99, 160, 251, 148, 18, 176, 202, 143, 100, 197, 188 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 132, 197, 159, 47, 243, 237, 113, 136, 75, 36, 192, 50, 68, 153, 210, 132, 33, 197, 165, 103, 221, 182, 33, 159, 2, 184, 25, 107, 179, 215, 21, 241, 241, 181, 145, 186, 241, 19, 251, 170, 92, 183, 90, 203, 201, 186, 6, 81, 73, 130, 31, 144, 215, 219, 244, 14, 216, 20, 156, 246, 129, 246, 6, 39 }, new byte[] { 179, 214, 175, 178, 243, 250, 158, 30, 22, 103, 210, 225, 235, 165, 146, 28, 219, 75, 121, 229, 57, 53, 138, 65, 78, 184, 180, 133, 235, 216, 138, 44, 193, 136, 78, 229, 218, 125, 95, 219, 184, 123, 55, 79, 87, 107, 32, 181, 197, 4, 119, 9, 1, 171, 99, 144, 78, 30, 33, 206, 137, 56, 60, 234, 1, 107, 184, 51, 225, 141, 178, 235, 126, 162, 41, 243, 225, 200, 249, 92, 193, 132, 53, 186, 183, 242, 87, 83, 58, 218, 61, 22, 121, 190, 196, 42, 162, 164, 80, 182, 8, 140, 46, 32, 156, 89, 115, 84, 248, 190, 174, 161, 73, 240, 29, 6, 224, 99, 160, 251, 148, 18, 176, 202, 143, 100, 197, 188 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 132, 197, 159, 47, 243, 237, 113, 136, 75, 36, 192, 50, 68, 153, 210, 132, 33, 197, 165, 103, 221, 182, 33, 159, 2, 184, 25, 107, 179, 215, 21, 241, 241, 181, 145, 186, 241, 19, 251, 170, 92, 183, 90, 203, 201, 186, 6, 81, 73, 130, 31, 144, 215, 219, 244, 14, 216, 20, 156, 246, 129, 246, 6, 39 }, new byte[] { 179, 214, 175, 178, 243, 250, 158, 30, 22, 103, 210, 225, 235, 165, 146, 28, 219, 75, 121, 229, 57, 53, 138, 65, 78, 184, 180, 133, 235, 216, 138, 44, 193, 136, 78, 229, 218, 125, 95, 219, 184, 123, 55, 79, 87, 107, 32, 181, 197, 4, 119, 9, 1, 171, 99, 144, 78, 30, 33, 206, 137, 56, 60, 234, 1, 107, 184, 51, 225, 141, 178, 235, 126, 162, 41, 243, 225, 200, 249, 92, 193, 132, 53, 186, 183, 242, 87, 83, 58, 218, 61, 22, 121, 190, 196, 42, 162, 164, 80, 182, 8, 140, 46, 32, 156, 89, 115, 84, 248, 190, 174, 161, 73, 240, 29, 6, 224, 99, 160, 251, 148, 18, 176, 202, 143, 100, 197, 188 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorariosDefinidos",
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
        }
    }
}