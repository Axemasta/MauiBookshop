using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookshop.DAL.Migrations;

/// <inheritdoc />
public partial class ExtraInformation : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Language",
            table: "Books",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Publisher",
            table: "Books",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Summary",
            table: "Books",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "Authors",
            type: "TEXT",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Language",
            table: "Books");

        migrationBuilder.DropColumn(
            name: "Publisher",
            table: "Books");

        migrationBuilder.DropColumn(
            name: "Summary",
            table: "Books");

        migrationBuilder.DropColumn(
            name: "Description",
            table: "Authors");
    }
}
