using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class MaterialsSEOAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoFollow",
                table: "Materials",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SeName",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "Materials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoFollow",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SeName",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "Materials");
        }
    }
}
