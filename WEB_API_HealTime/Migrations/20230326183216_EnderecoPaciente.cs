using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecoPessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    NroLogradouro = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    BairroLogradouro = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    CidadeEndereco = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    UFEndereco = table.Column<string>(type: "CHAR(2)", nullable: false),
                    CEPEndereco = table.Column<string>(type: "CHAR(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FK_EnderecoPessoa", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_PK_EnderecoPessoa",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 161, 152, 152, 177, 55, 225, 15, 53, 120, 171, 85, 234, 52, 49, 134, 79, 152, 108, 85, 24, 91, 204, 125, 209, 135, 206, 134, 163, 123, 213, 16, 38, 22, 144, 83, 52, 67, 78, 24, 118, 28, 136, 229, 168, 151, 205, 199, 6, 150, 151, 67, 77, 45, 32, 168, 253, 48, 219, 38, 72, 26, 47, 169, 86 }, new byte[] { 42, 193, 90, 160, 121, 46, 168, 5, 107, 245, 70, 120, 224, 132, 211, 224, 173, 0, 2, 176, 169, 233, 225, 38, 56, 18, 116, 116, 19, 229, 126, 209, 202, 32, 131, 94, 42, 214, 102, 117, 196, 110, 243, 148, 128, 138, 149, 61, 136, 20, 8, 190, 152, 218, 66, 145, 119, 187, 212, 251, 175, 1, 245, 19, 13, 224, 89, 198, 35, 15, 36, 13, 215, 145, 125, 152, 240, 20, 232, 245, 116, 31, 2, 120, 11, 178, 200, 209, 8, 107, 100, 33, 172, 191, 39, 253, 154, 138, 39, 178, 134, 224, 95, 44, 17, 90, 175, 127, 196, 132, 72, 110, 96, 216, 95, 30, 82, 242, 187, 27, 253, 218, 174, 201, 56, 73, 163, 216 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoPessoa");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 128, 235, 171, 166, 185, 233, 109, 229, 173, 73, 111, 236, 178, 201, 202, 243, 100, 246, 198, 102, 179, 251, 202, 65, 251, 172, 205, 227, 200, 187, 22, 65, 2, 99, 80, 158, 60, 185, 55, 64, 207, 24, 91, 127, 38, 180, 156, 61, 188, 179, 47, 159, 181, 224, 163, 111, 39, 205, 252, 56, 143, 19, 195 }, new byte[] { 103, 52, 87, 58, 7, 160, 117, 226, 132, 57, 134, 222, 246, 86, 125, 64, 47, 185, 251, 169, 145, 3, 131, 150, 139, 122, 252, 206, 173, 178, 137, 232, 19, 250, 234, 210, 244, 216, 10, 85, 162, 227, 130, 124, 141, 116, 207, 24, 179, 82, 202, 82, 75, 229, 50, 167, 147, 156, 94, 33, 178, 244, 222, 242, 67, 3, 159, 88, 94, 237, 70, 176, 121, 30, 138, 161, 88, 179, 32, 119, 222, 134, 241, 31, 253, 93, 75, 224, 123, 25, 20, 210, 62, 104, 205, 42, 112, 231, 242, 202, 121, 131, 196, 154, 102, 65, 96, 226, 253, 40, 189, 233, 208, 114, 79, 230, 79, 40, 137, 191, 149, 25, 5, 239, 200, 36, 185, 209 } });
        }
    }
}
