using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenstandDatabaseProjectForFI.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedGenstand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accenssion",
                table: "Genstands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Genstands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfGenstand",
                table: "Genstands",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "Loan",
                table: "Genstands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhotoReference",
                table: "Genstands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placement",
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

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Genstands",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accenssion",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "DateOfGenstand",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Loan",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "PhotoReference",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Placement",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Presavation",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Provenance",
                table: "Genstands");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Genstands");
        }
    }
}
