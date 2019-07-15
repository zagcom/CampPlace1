using Microsoft.EntityFrameworkCore.Migrations;

namespace CampplaceTest1.Data.Migrations
{
    public partial class IncludeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Camp",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Camp_ApplicationUserId",
                table: "Camp",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Camp_AspNetUsers_ApplicationUserId",
                table: "Camp",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camp_AspNetUsers_ApplicationUserId",
                table: "Camp");

            migrationBuilder.DropIndex(
                name: "IX_Camp_ApplicationUserId",
                table: "Camp");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Camp");
        }
    }
}
