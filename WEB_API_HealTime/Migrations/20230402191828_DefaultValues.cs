using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrescricoesMedicacoes_PrescricaoPacienteId",
                table: "PrescricoesMedicacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContatoPessoaId",
                table: "ContatoPessoas");

            migrationBuilder.DropIndex(
                name: "IX_ContatoPessoas_PessoaId",
                table: "ContatoPessoas");

            migrationBuilder.DropColumn(
                name: "ContatoPessoaId",
                table: "ContatoPessoas");

            migrationBuilder.DropColumn(
                name: "TipoContato",
                table: "ContatoPessoas");

            migrationBuilder.AlterColumn<string>(
                name: "TelefoneSecundario",
                table: "ContatoPessoas",
                type: "CHAR(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "ContatoPessoas",
                type: "CHAR(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "ContatoPessoas",
                type: "CHAR(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AtualizadoEm",
                table: "ContatoPessoas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CelularSecundario",
                table: "ContatoPessoas",
                type: "CHAR(11)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContatoPessoaId",
                table: "ContatoPessoas",
                column: "PessoaId");

            migrationBuilder.InsertData(
                table: "ContatoPessoas",
                columns: new[] { "PessoaId", "AtualizadoEm", "Celular", "CelularSecundario", "CriadoEm", "Email", "Telefone", "TelefoneSecundario" },
                values: new object[] { 1, null, "11978486810", null, new DateTime(2023, 4, 2, 16, 18, 27, 997, DateTimeKind.Local).AddTicks(2909), "user@user.com", null, null });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 249, 39, 1, 236, 202, 205, 140, 4, 26, 90, 87, 123, 232, 208, 67, 218, 195, 100, 155, 65, 63, 114, 249, 204, 202, 98, 112, 100, 162, 74, 135, 233, 176, 132, 175, 81, 29, 52, 136, 189, 229, 126, 71, 108, 76, 81, 123, 61, 79, 159, 164, 232, 36, 72, 67, 18, 16, 248, 80, 220, 17, 3, 75, 147 }, new byte[] { 82, 156, 67, 44, 171, 192, 186, 21, 165, 73, 150, 47, 119, 242, 160, 202, 190, 235, 27, 161, 86, 63, 128, 210, 191, 140, 206, 36, 175, 239, 152, 217, 249, 206, 13, 245, 227, 56, 204, 82, 155, 254, 22, 114, 29, 248, 111, 95, 255, 20, 81, 47, 186, 36, 182, 148, 13, 43, 17, 131, 178, 125, 16, 32, 13, 239, 227, 215, 102, 32, 195, 33, 126, 31, 162, 168, 105, 233, 112, 32, 130, 201, 245, 4, 146, 140, 40, 27, 211, 205, 67, 164, 120, 212, 254, 117, 30, 55, 222, 21, 226, 171, 152, 237, 95, 20, 26, 34, 5, 88, 222, 222, 153, 154, 234, 74, 239, 15, 231, 162, 51, 234, 163, 204, 53, 99, 193, 123 } });

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPessoas_Email",
                table: "ContatoPessoas",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContatoPessoaId",
                table: "ContatoPessoas");

            migrationBuilder.DropIndex(
                name: "IX_ContatoPessoas_Email",
                table: "ContatoPessoas");

            migrationBuilder.DeleteData(
                table: "ContatoPessoas",
                keyColumn: "PessoaId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CelularSecundario",
                table: "ContatoPessoas");

            migrationBuilder.AlterColumn<string>(
                name: "TelefoneSecundario",
                table: "ContatoPessoas",
                type: "CHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "ContatoPessoas",
                type: "CHAR(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "ContatoPessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AtualizadoEm",
                table: "ContatoPessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContatoPessoaId",
                table: "ContatoPessoas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TipoContato",
                table: "ContatoPessoas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContatoPessoaId",
                table: "ContatoPessoas",
                column: "ContatoPessoaId");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 255, 202, 227, 108, 69, 125, 79, 91, 32, 213, 46, 202, 197, 10, 220, 249, 246, 21, 94, 154, 51, 88, 98, 114, 109, 40, 51, 232, 135, 246, 73, 64, 197, 230, 172, 218, 72, 235, 87, 29, 159, 129, 175, 92, 115, 48, 160, 97, 130, 204, 88, 85, 140, 142, 41, 244, 87, 136, 81, 46, 58, 214, 161, 88 }, new byte[] { 6, 219, 162, 188, 27, 39, 91, 197, 60, 207, 205, 173, 169, 90, 253, 23, 183, 216, 245, 81, 95, 14, 53, 156, 62, 40, 41, 225, 239, 189, 253, 149, 20, 26, 100, 203, 146, 94, 184, 102, 243, 248, 222, 234, 137, 33, 168, 201, 184, 217, 121, 239, 210, 128, 161, 20, 199, 87, 108, 138, 44, 74, 37, 241, 5, 77, 106, 249, 35, 145, 83, 118, 27, 168, 169, 18, 28, 190, 168, 65, 69, 126, 229, 4, 243, 80, 36, 129, 88, 225, 115, 227, 124, 49, 50, 78, 237, 172, 62, 157, 67, 60, 60, 97, 227, 254, 42, 253, 93, 40, 72, 231, 55, 149, 85, 134, 198, 208, 121, 98, 100, 86, 108, 116, 140, 64, 50, 42 } });

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicacoes_PrescricaoPacienteId",
                table: "PrescricoesMedicacoes",
                column: "PrescricaoPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPessoas_PessoaId",
                table: "ContatoPessoas",
                column: "PessoaId",
                unique: true);
        }
    }
}
