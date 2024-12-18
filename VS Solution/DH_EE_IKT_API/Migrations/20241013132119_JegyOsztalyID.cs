using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DH_EE_IKT_API.Migrations
{
    /// <inheritdoc />
    public partial class JegyOsztalyID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Osztaly_ID",
                table: "Jegyek",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Osztaly_ID",
                table: "Jegyek");
        }
    }
}
