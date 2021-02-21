using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class SubId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubpageId",
                table: "Topic",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_SubpageId",
                table: "Topic",
                column: "SubpageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Topic_SubpageId",
                table: "Topic",
                column: "SubpageId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Topic_SubpageId",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_SubpageId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "SubpageId",
                table: "Topic");
        }
    }
}
