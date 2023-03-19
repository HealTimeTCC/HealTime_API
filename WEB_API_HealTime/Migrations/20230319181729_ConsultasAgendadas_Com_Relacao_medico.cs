using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class ConsultasAgendadas_Com_Relacao_medico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultasAgendadas",
                columns: table => new
                {
                    ConsultasAgendadasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusConsultasId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    DataSolicitacaoConsulta = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "DATE", nullable: false),
                    MotivoConsulta = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Encaminhamento = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaAgendadaId", x => x.ConsultasAgendadasId);
                    table.ForeignKey(
                        name: "FK_MedicoId_ConsultaAgendadaId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusConsultas",
                columns: table => new
                {
                    StatusConsultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusConsultas", x => x.StatusConsultaId);
                });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 209, 89, 174, 250, 246, 40, 155, 173, 168, 176, 167, 107, 42, 190, 222, 205, 13, 74, 117, 174, 255, 103, 243, 6, 224, 29, 179, 107, 225, 91, 60, 96, 162, 170, 14, 79, 134, 206, 163, 75, 110, 112, 160, 215, 29, 50, 96, 16, 20, 19, 15, 2, 245, 183, 22, 19, 41, 103, 172, 47, 133, 166, 123, 58 }, new byte[] { 221, 252, 226, 120, 53, 97, 92, 111, 69, 154, 132, 204, 2, 67, 42, 85, 16, 99, 225, 152, 102, 72, 173, 17, 238, 71, 13, 113, 220, 29, 61, 74, 71, 146, 176, 234, 122, 153, 81, 149, 130, 206, 107, 230, 20, 125, 42, 225, 238, 252, 79, 37, 239, 4, 248, 205, 167, 161, 182, 38, 88, 251, 159, 187, 243, 34, 57, 186, 30, 53, 212, 83, 66, 132, 149, 55, 18, 136, 105, 47, 140, 171, 65, 113, 46, 159, 155, 154, 45, 63, 233, 193, 119, 8, 123, 123, 228, 58, 76, 15, 121, 143, 228, 244, 76, 84, 175, 147, 175, 92, 17, 185, 58, 15, 112, 13, 249, 25, 195, 174, 234, 250, 247, 244, 228, 201, 143, 227 } });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_MedicoId",
                table: "ConsultasAgendadas",
                column: "MedicoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasAgendadas");

            migrationBuilder.DropTable(
                name: "StatusConsultas");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 232, 25, 35, 211, 168, 216, 139, 52, 47, 214, 57, 196, 83, 161, 38, 156, 125, 216, 181, 123, 163, 83, 96, 233, 85, 143, 142, 154, 46, 187, 147, 49, 157, 117, 153, 132, 208, 89, 225, 42, 22, 190, 176, 1, 46, 33, 142, 29, 218, 14, 255, 95, 197, 181, 164, 124, 58, 110, 176, 85, 173, 204, 248, 202 }, new byte[] { 67, 87, 137, 1, 231, 223, 240, 40, 244, 225, 54, 240, 18, 111, 241, 215, 45, 146, 178, 8, 20, 34, 66, 147, 154, 249, 148, 197, 113, 8, 37, 126, 151, 67, 127, 148, 132, 224, 2, 204, 55, 85, 148, 15, 238, 164, 12, 207, 191, 78, 99, 248, 139, 2, 232, 10, 72, 152, 131, 103, 170, 9, 163, 242, 110, 212, 5, 213, 244, 98, 223, 234, 81, 16, 157, 221, 162, 234, 82, 247, 88, 236, 4, 110, 55, 255, 11, 169, 237, 239, 22, 96, 34, 218, 103, 224, 233, 240, 195, 74, 251, 31, 122, 29, 233, 63, 98, 198, 65, 72, 239, 163, 11, 163, 204, 113, 54, 77, 32, 57, 36, 74, 170, 138, 27, 161, 53, 151 } });
        }
    }
}
