using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenstandDatabaseProjectForFI.Migrations
{
    /// <inheritdoc />
    public partial class GenstandReady : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accenssion",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Presavation",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Provenance",
                table: "Genstands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accenssion",
                table: "Genstands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Presavation",
                table: "Genstands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Provenance",
                table: "Genstands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
