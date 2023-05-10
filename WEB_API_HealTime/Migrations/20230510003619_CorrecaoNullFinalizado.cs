using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoNullFinalizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusMedicacaoFlag",
                table: "PrescricoesMedicacoes",
                type: "CHAR(1)",
                nullable: false,
                defaultValue: "S",
                oldClrType: typeof(string),
                oldType: "CHAR(1)",
                oldNullable: true,
                oldDefaultValue: "S");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Pessoas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Pessoas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalizadoEm",
                table: "CuidadorPacientes",
                type: "DATETIME2(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2(0)");

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 5, 9, 21, 36, 19, 292, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 123, 41, 147, 208, 69, 77, 195, 184, 189, 233, 164, 63, 169, 172, 202, 135, 243, 236, 242, 234, 181, 39, 28, 102, 244, 230, 45, 113, 92, 129, 252, 244, 184, 61, 155, 38, 110, 36, 19, 81, 97, 114, 156, 17, 166, 17, 234, 207, 181, 254, 79, 86, 136, 39, 7, 0, 140, 105, 117, 22, 200, 202, 53, 42 }, new byte[] { 103, 19, 78, 96, 52, 202, 139, 116, 4, 58, 18, 237, 119, 65, 109, 70, 22, 98, 194, 115, 213, 41, 37, 94, 71, 49, 87, 232, 175, 88, 17, 77, 214, 149, 193, 61, 169, 9, 12, 212, 103, 203, 104, 228, 87, 59, 23, 3, 37, 242, 82, 122, 151, 170, 139, 22, 238, 47, 246, 60, 133, 225, 118, 190, 38, 146, 253, 212, 190, 159, 95, 42, 81, 59, 104, 250, 29, 212, 139, 145, 151, 165, 36, 184, 74, 154, 117, 100, 91, 119, 229, 47, 124, 99, 187, 54, 14, 149, 239, 86, 85, 49, 170, 53, 192, 174, 158, 118, 60, 55, 60, 14, 243, 69, 196, 151, 230, 0, 102, 173, 128, 14, 101, 193, 91, 35, 34, 11 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 123, 41, 147, 208, 69, 77, 195, 184, 189, 233, 164, 63, 169, 172, 202, 135, 243, 236, 242, 234, 181, 39, 28, 102, 244, 230, 45, 113, 92, 129, 252, 244, 184, 61, 155, 38, 110, 36, 19, 81, 97, 114, 156, 17, 166, 17, 234, 207, 181, 254, 79, 86, 136, 39, 7, 0, 140, 105, 117, 22, 200, 202, 53, 42 }, new byte[] { 103, 19, 78, 96, 52, 202, 139, 116, 4, 58, 18, 237, 119, 65, 109, 70, 22, 98, 194, 115, 213, 41, 37, 94, 71, 49, 87, 232, 175, 88, 17, 77, 214, 149, 193, 61, 169, 9, 12, 212, 103, 203, 104, 228, 87, 59, 23, 3, 37, 242, 82, 122, 151, 170, 139, 22, 238, 47, 246, 60, 133, 225, 118, 190, 38, 146, 253, 212, 190, 159, 95, 42, 81, 59, 104, 250, 29, 212, 139, 145, 151, 165, 36, 184, 74, 154, 117, 100, 91, 119, 229, 47, 124, 99, 187, 54, 14, 149, 239, 86, 85, 49, 170, 53, 192, 174, 158, 118, 60, 55, 60, 14, 243, 69, 196, 151, 230, 0, 102, 173, 128, 14, 101, 193, 91, 35, 34, 11 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 123, 41, 147, 208, 69, 77, 195, 184, 189, 233, 164, 63, 169, 172, 202, 135, 243, 236, 242, 234, 181, 39, 28, 102, 244, 230, 45, 113, 92, 129, 252, 244, 184, 61, 155, 38, 110, 36, 19, 81, 97, 114, 156, 17, 166, 17, 234, 207, 181, 254, 79, 86, 136, 39, 7, 0, 140, 105, 117, 22, 200, 202, 53, 42 }, new byte[] { 103, 19, 78, 96, 52, 202, 139, 116, 4, 58, 18, 237, 119, 65, 109, 70, 22, 98, 194, 115, 213, 41, 37, 94, 71, 49, 87, 232, 175, 88, 17, 77, 214, 149, 193, 61, 169, 9, 12, 212, 103, 203, 104, 228, 87, 59, 23, 3, 37, 242, 82, 122, 151, 170, 139, 22, 238, 47, 246, 60, 133, 225, 118, 190, 38, 146, 253, 212, 190, 159, 95, 42, 81, 59, 104, 250, 29, 212, 139, 145, 151, 165, 36, 184, 74, 154, 117, 100, 91, 119, 229, 47, 124, 99, 187, 54, 14, 149, 239, 86, 85, 49, 170, 53, 192, 174, 158, 118, 60, 55, 60, 14, 243, 69, 196, 151, 230, 0, 102, 173, 128, 14, 101, 193, 91, 35, 34, 11 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 123, 41, 147, 208, 69, 77, 195, 184, 189, 233, 164, 63, 169, 172, 202, 135, 243, 236, 242, 234, 181, 39, 28, 102, 244, 230, 45, 113, 92, 129, 252, 244, 184, 61, 155, 38, 110, 36, 19, 81, 97, 114, 156, 17, 166, 17, 234, 207, 181, 254, 79, 86, 136, 39, 7, 0, 140, 105, 117, 22, 200, 202, 53, 42 }, new byte[] { 103, 19, 78, 96, 52, 202, 139, 116, 4, 58, 18, 237, 119, 65, 109, 70, 22, 98, 194, 115, 213, 41, 37, 94, 71, 49, 87, 232, 175, 88, 17, 77, 214, 149, 193, 61, 169, 9, 12, 212, 103, 203, 104, 228, 87, 59, 23, 3, 37, 242, 82, 122, 151, 170, 139, 22, 238, 47, 246, 60, 133, 225, 118, 190, 38, 146, 253, 212, 190, 159, 95, 42, 81, 59, 104, 250, 29, 212, 139, 145, 151, 165, 36, 184, 74, 154, 117, 100, 91, 119, 229, 47, 124, 99, 187, 54, 14, 149, 239, 86, 85, 49, 170, 53, 192, 174, 158, 118, 60, 55, 60, 14, 243, 69, 196, 151, 230, 0, 102, 173, 128, 14, 101, 193, 91, 35, 34, 11 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusMedicacaoFlag",
                table: "PrescricoesMedicacoes",
                type: "CHAR(1)",
                nullable: true,
                defaultValue: "S",
                oldClrType: typeof(string),
                oldType: "CHAR(1)",
                oldDefaultValue: "S");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Pessoas",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Pessoas",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalizadoEm",
                table: "CuidadorPacientes",
                type: "DATETIME2(0)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2(0)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 5, 6, 18, 12, 54, 272, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 } });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 } });
        }
    }
}
