using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class DefaultTipoMedicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusConsultas",
                table: "StatusConsultas");

            migrationBuilder.AlterColumn<string>(
                name: "DescStatusConsulta",
                table: "StatusConsultas",
                type: "VARCHAR(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultaCanceladaId",
                table: "ConsultasAgendadas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusConsultaId",
                table: "StatusConsultas",
                column: "StatusConsultaId");

            migrationBuilder.CreateTable(
                name: "ConsultaCanceladas",
                columns: table => new
                {
                    ConsultaCanceladaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaAgendadaId = table.Column<int>(type: "int", nullable: false),
                    MotivoCancelamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCancelamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaCanceladas", x => x.ConsultaCanceladaId);
                });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 47, 237, 6, 146, 4, 176, 222, 225, 231, 104, 215, 228, 11, 27, 191, 89, 28, 179, 212, 139, 208, 32, 101, 17, 62, 177, 247, 4, 17, 35, 77, 81, 82, 135, 55, 74, 151, 52, 127, 52, 103, 48, 222, 108, 188, 145, 29, 5, 26, 174, 139, 195, 188, 223, 205, 34, 143, 38, 214, 22, 41, 164, 46, 40 }, new byte[] { 96, 1, 152, 2, 207, 148, 83, 203, 154, 28, 91, 176, 39, 3, 213, 48, 100, 224, 132, 115, 80, 229, 41, 136, 140, 67, 86, 234, 79, 113, 44, 250, 204, 109, 8, 187, 251, 224, 32, 178, 210, 4, 182, 128, 94, 59, 253, 254, 168, 4, 164, 104, 89, 236, 129, 175, 143, 159, 217, 216, 140, 32, 135, 173, 104, 37, 194, 122, 208, 94, 158, 54, 198, 235, 172, 143, 39, 85, 228, 136, 236, 55, 143, 177, 95, 90, 240, 245, 185, 156, 79, 151, 252, 199, 112, 52, 125, 143, 182, 200, 134, 40, 10, 184, 141, 156, 180, 35, 42, 79, 132, 66, 66, 212, 216, 188, 145, 103, 6, 17, 121, 71, 92, 239, 251, 95, 250, 28 } });

            migrationBuilder.InsertData(
                table: "StatusConsultas",
                columns: new[] { "StatusConsultaId", "DescStatusConsulta" },
                values: new object[,]
                {
                    { 1, "Encerrada" },
                    { 2, "Agendada" },
                    { 3, "Cancelada" },
                    { 4, "Remarcada" },
                    { 5, "Fila de espera" }
                });

            migrationBuilder.UpdateData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 1,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Aplicado pela boca", "Via oral" });

            migrationBuilder.UpdateData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 2,
                columns: new[] { "ClasseAplicacao", "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { 1, "Aplicado  por dembaixo da língua", "Sublingual" });

            migrationBuilder.InsertData(
                table: "TiposMedicacoes",
                columns: new[] { "TipoMedicacaoId", "ClasseAplicacao", "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[,]
                {
                    { 3, 1, "Aplicado pelo canal retal", "Supositorios" },
                    { 4, 2, "Aplicada diretamente no sangue", "Intravenosa" },
                    { 5, 2, "Aplicada diretamente no músculo", "Intramuscular" },
                    { 6, 2, "Aplicada debaixo da pele", "Subcutânea" },
                    { 7, 2, "", "Respiratória" },
                    { 8, 2, "Aplicada por pomadas", "Via tópica" },
                    { 9, 2, "", "Via Ocular" },
                    { 10, 2, "", "Via Nasal" },
                    { 11, 2, "", "Via Auricular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_ConsultaCanceladaId",
                table: "ConsultasAgendadas",
                column: "ConsultaCanceladaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_StatusConsultasId",
                table: "ConsultasAgendadas",
                column: "StatusConsultasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaAgendadas_StatusConsulta",
                table: "ConsultasAgendadas",
                column: "StatusConsultasId",
                principalTable: "StatusConsultas",
                principalColumn: "StatusConsultaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasAgendadas_ConsultaCanceladas_ConsultaCanceladaId",
                table: "ConsultasAgendadas",
                column: "ConsultaCanceladaId",
                principalTable: "ConsultaCanceladas",
                principalColumn: "ConsultaCanceladaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaAgendadas_StatusConsulta",
                table: "ConsultasAgendadas");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasAgendadas_ConsultaCanceladas_ConsultaCanceladaId",
                table: "ConsultasAgendadas");

            migrationBuilder.DropTable(
                name: "ConsultaCanceladas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusConsultaId",
                table: "StatusConsultas");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasAgendadas_ConsultaCanceladaId",
                table: "ConsultasAgendadas");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasAgendadas_StatusConsultasId",
                table: "ConsultasAgendadas");

            migrationBuilder.DeleteData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StatusConsultas",
                keyColumn: "StatusConsultaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "ConsultaCanceladaId",
                table: "ConsultasAgendadas");

            migrationBuilder.AlterColumn<string>(
                name: "DescStatusConsulta",
                table: "StatusConsultas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(25)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusConsultas",
                table: "StatusConsultas",
                column: "StatusConsultaId");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 209, 89, 174, 250, 246, 40, 155, 173, 168, 176, 167, 107, 42, 190, 222, 205, 13, 74, 117, 174, 255, 103, 243, 6, 224, 29, 179, 107, 225, 91, 60, 96, 162, 170, 14, 79, 134, 206, 163, 75, 110, 112, 160, 215, 29, 50, 96, 16, 20, 19, 15, 2, 245, 183, 22, 19, 41, 103, 172, 47, 133, 166, 123, 58 }, new byte[] { 221, 252, 226, 120, 53, 97, 92, 111, 69, 154, 132, 204, 2, 67, 42, 85, 16, 99, 225, 152, 102, 72, 173, 17, 238, 71, 13, 113, 220, 29, 61, 74, 71, 146, 176, 234, 122, 153, 81, 149, 130, 206, 107, 230, 20, 125, 42, 225, 238, 252, 79, 37, 239, 4, 248, 205, 167, 161, 182, 38, 88, 251, 159, 187, 243, 34, 57, 186, 30, 53, 212, 83, 66, 132, 149, 55, 18, 136, 105, 47, 140, 171, 65, 113, 46, 159, 155, 154, 45, 63, 233, 193, 119, 8, 123, 123, 228, 58, 76, 15, 121, 143, 228, 244, 76, 84, 175, 147, 175, 92, 17, 185, 58, 15, 112, 13, 249, 25, 195, 174, 234, 250, 247, 244, 228, 201, 143, 227 } });

            migrationBuilder.UpdateData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 1,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Experimental", "NASAL" });

            migrationBuilder.UpdateData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 2,
                columns: new[] { "ClasseAplicacao", "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { 2, "Experimental EXPERIMENTE CALADO", "PILULA" });
        }
    }
}
