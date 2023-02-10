using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class CuidadorPacienteFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "CuidadorPacientes",
                type: "SMALLDATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "CuidadorPacientes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
