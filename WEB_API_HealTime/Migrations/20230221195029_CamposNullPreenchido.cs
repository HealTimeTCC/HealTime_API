using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class CamposNullPreenchido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 1,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Aplicação pela boca", "Via oral" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 2,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Aplicação por debaixo da lingua", "Sublingual" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 3,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Aplicação retal", "Supositorios" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 4,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Direta no sangue", "Intravenosa" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 5,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Direta no músculo", "Intramuscular" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 6,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Debaixo da pele", "Subcutânea" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 7,
                column: "DescMedicacao",
                value: "Via que se estende desde a mucosa nasal até os pulmões");

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 8,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { "Aplicação na pele (Pomadas)", "Via tópica" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 9,
                column: "DescMedicacao",
                value: "Aplicação direta no olho");

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 10,
                column: "DescMedicacao",
                value: "Aplicação pelo nariz");

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 11,
                column: "DescMedicacao",
                value: "Aplicação no ouvido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 1,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { null, "Via oral (boca)" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 2,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { null, "Sublingual (embaixo da língua)" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 3,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { null, "Supositorios (Retal)" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 4,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { null, "Intravenosa (Direta no sangue)" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 5,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { null, "Intramuscular (Direta no músculo)" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 6,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { null, "Subcutânea (Debaixo da pele)" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 7,
                column: "DescMedicacao",
                value: null);

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 8,
                columns: new[] { "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[] { null, "Via tópica (Pomadas)" });

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 9,
                column: "DescMedicacao",
                value: null);

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 10,
                column: "DescMedicacao",
                value: null);

            migrationBuilder.UpdateData(
                table: "TipoMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 11,
                column: "DescMedicacao",
                value: null);
        }
    }
}
