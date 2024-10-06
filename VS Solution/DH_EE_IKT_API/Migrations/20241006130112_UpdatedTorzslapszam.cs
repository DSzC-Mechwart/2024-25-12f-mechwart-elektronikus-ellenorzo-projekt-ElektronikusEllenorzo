using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DH_EE_IKT_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTorzslapszam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Torzslapszam",
                table: "Tanulok",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Torzslapszam",
                table: "Tanulok",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
