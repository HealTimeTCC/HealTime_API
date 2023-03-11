using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class TypeSecurity_continuation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Pessoas",
                type: "BINARY",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "VARBINARY");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Pessoas",
                type: "BINARY",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "VARBINARY");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Pessoas",
                type: "VARBINARY",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BINARY");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Pessoas",
                type: "VARBINARY",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BINARY");
        }
    }
}
