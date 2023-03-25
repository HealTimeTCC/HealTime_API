﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 36, 178, 39, 68, 35, 241, 239, 253, 254, 193, 139, 104, 196, 208, 55, 0, 7, 121, 183, 172, 187, 75, 67, 99, 86, 232, 114, 43, 217, 195, 227, 232, 224, 22, 199, 170, 53, 60, 248, 49, 110, 43, 27, 171, 3, 133, 240, 200, 177, 184, 228, 92, 54, 98, 57, 116, 225, 23, 233, 234, 166, 189, 34 }, new byte[] { 243, 165, 39, 132, 93, 16, 236, 54, 211, 19, 150, 185, 24, 2, 185, 12, 10, 175, 1, 14, 113, 40, 176, 49, 17, 130, 38, 165, 104, 117, 253, 207, 218, 75, 192, 180, 178, 32, 191, 191, 111, 208, 57, 34, 60, 229, 10, 175, 97, 237, 56, 174, 70, 66, 171, 165, 125, 32, 80, 157, 169, 215, 0, 235, 37, 132, 196, 99, 24, 160, 222, 214, 221, 91, 133, 153, 107, 23, 11, 226, 193, 156, 222, 165, 115, 27, 239, 166, 52, 42, 125, 56, 58, 186, 166, 165, 174, 154, 54, 218, 67, 192, 47, 117, 161, 6, 22, 164, 214, 238, 39, 25, 255, 228, 101, 131, 90, 249, 141, 224, 250, 212, 129, 39, 32, 165, 189, 61 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 84, 196, 101, 235, 70, 42, 193, 114, 198, 213, 161, 99, 24, 228, 196, 93, 137, 128, 243, 254, 60, 34, 8, 141, 233, 204, 38, 121, 80, 75, 221, 202, 35, 80, 163, 189, 130, 123, 173, 27, 97, 41, 46, 91, 3, 90, 66, 184, 64, 96, 230, 180, 226, 8, 236, 69, 129, 110, 237, 45, 53, 41, 51, 120 }, new byte[] { 49, 236, 69, 221, 124, 121, 1, 71, 217, 23, 205, 56, 22, 244, 94, 157, 74, 33, 76, 250, 74, 242, 137, 59, 152, 175, 3, 75, 161, 82, 200, 239, 177, 196, 132, 120, 216, 239, 38, 89, 96, 39, 120, 222, 112, 234, 103, 208, 99, 79, 49, 124, 217, 147, 23, 187, 206, 54, 74, 216, 83, 73, 145, 182, 73, 188, 139, 105, 207, 182, 233, 57, 18, 117, 220, 255, 233, 222, 150, 110, 114, 141, 145, 235, 60, 199, 146, 208, 109, 181, 224, 230, 198, 144, 179, 122, 233, 103, 46, 215, 64, 170, 41, 133, 234, 103, 55, 219, 72, 216, 233, 198, 105, 22, 118, 98, 18, 229, 155, 69, 138, 127, 114, 255, 140, 5, 237, 114 } });
        }
    }
}
