using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoPessoas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPessoaId",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "StatusConsultasId",
                table: "ConsultasAgendadas",
                newName: "StatusConsultaId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultasAgendadas_StatusConsultasId",
                table: "ConsultasAgendadas",
                newName: "IX_ConsultasAgendadas_StatusConsultaId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNascPessoa",
                table: "Pessoas",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoa",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataSolicitacaoConsulta",
                table: "ConsultasAgendadas",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConsulta",
                table: "ConsultasAgendadas",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCancelamento",
                table: "ConsultaCanceladas",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "TipoPessoa" },
                values: new object[] { new byte[] { 196, 108, 45, 136, 136, 154, 199, 121, 14, 222, 88, 198, 102, 25, 159, 141, 134, 58, 117, 190, 114, 183, 52, 235, 61, 94, 152, 77, 232, 105, 100, 65, 91, 230, 168, 75, 66, 48, 227, 188, 207, 86, 211, 101, 69, 204, 43, 193, 20, 21, 243, 152, 174, 149, 33, 110, 104, 129, 236, 48, 249, 99, 21, 65 }, new byte[] { 84, 51, 202, 234, 37, 244, 59, 157, 203, 35, 199, 221, 74, 93, 11, 96, 176, 14, 15, 237, 83, 202, 111, 227, 184, 158, 166, 251, 83, 54, 5, 186, 228, 0, 28, 8, 79, 50, 227, 202, 65, 123, 79, 129, 42, 117, 10, 105, 237, 116, 130, 242, 167, 11, 76, 224, 209, 157, 80, 178, 224, 251, 144, 170, 242, 47, 195, 44, 92, 130, 125, 254, 142, 20, 7, 68, 157, 242, 9, 190, 66, 241, 79, 49, 211, 124, 33, 255, 251, 1, 90, 118, 202, 52, 197, 209, 211, 182, 225, 145, 146, 155, 58, 237, 24, 180, 101, 11, 197, 84, 50, 77, 95, 243, 190, 19, 239, 215, 60, 65, 97, 89, 238, 205, 138, 126, 194, 91 }, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "StatusConsultaId",
                table: "ConsultasAgendadas",
                newName: "StatusConsultasId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultasAgendadas_StatusConsultaId",
                table: "ConsultasAgendadas",
                newName: "IX_ConsultasAgendadas_StatusConsultasId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNascPessoa",
                table: "Pessoas",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoaId",
                table: "Pessoas",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataSolicitacaoConsulta",
                table: "ConsultasAgendadas",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConsulta",
                table: "ConsultasAgendadas",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCancelamento",
                table: "ConsultaCanceladas",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "TipoPessoaId" },
                values: new object[] { new byte[] { 161, 152, 152, 177, 55, 225, 15, 53, 120, 171, 85, 234, 52, 49, 134, 79, 152, 108, 85, 24, 91, 204, 125, 209, 135, 206, 134, 163, 123, 213, 16, 38, 22, 144, 83, 52, 67, 78, 24, 118, 28, 136, 229, 168, 151, 205, 199, 6, 150, 151, 67, 77, 45, 32, 168, 253, 48, 219, 38, 72, 26, 47, 169, 86 }, new byte[] { 42, 193, 90, 160, 121, 46, 168, 5, 107, 245, 70, 120, 224, 132, 211, 224, 173, 0, 2, 176, 169, 233, 225, 38, 56, 18, 116, 116, 19, 229, 126, 209, 202, 32, 131, 94, 42, 214, 102, 117, 196, 110, 243, 148, 128, 138, 149, 61, 136, 20, 8, 190, 152, 218, 66, 145, 119, 187, 212, 251, 175, 1, 245, 19, 13, 224, 89, 198, 35, 15, 36, 13, 215, 145, 125, 152, 240, 20, 232, 245, 116, 31, 2, 120, 11, 178, 200, 209, 8, 107, 100, 33, 172, 191, 39, 253, 154, 138, 39, 178, 134, 224, 95, 44, 17, 90, 175, 127, 196, 132, 72, 110, 96, 216, 95, 30, 82, 242, 187, 27, 253, 218, 174, 201, 56, 73, 163, 216 }, 1 });
        }
    }
}
