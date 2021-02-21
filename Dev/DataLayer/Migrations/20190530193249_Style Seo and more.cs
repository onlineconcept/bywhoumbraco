using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class StyleSeoandmore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoFollow",
                table: "Styles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "Styles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "Styles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "Styles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoFollow",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "Styles");
        }
    }
}
