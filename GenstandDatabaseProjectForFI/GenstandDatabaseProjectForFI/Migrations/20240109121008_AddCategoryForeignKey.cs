using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenstandDatabaseProjectForFI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Column",
                table: "Locations",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Genstands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Genstands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genstands_CategoryId",
                table: "Genstands",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Genstands_LocationId",
                table: "Genstands",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genstands_Categories_CategoryId",
                table: "Genstands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genstands_Locations_LocationId",
                table: "Genstands",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genstands_Categories_CategoryId",
                table: "Genstands");

            migrationBuilder.DropForeignKey(
                name: "FK_Genstands_Locations_LocationId",
                table: "Genstands");

            migrationBuilder.DropIndex(
                name: "IX_Genstands_CategoryId",
                table: "Genstands");

            migrationBuilder.DropIndex(
                name: "IX_Genstands_LocationId",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Genstands");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "Column");
        }
    }
}
