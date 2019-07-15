using Microsoft.EntityFrameworkCore.Migrations;

namespace CampplaceTest1.Data.Migrations
{
    public partial class UserNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Camp",
                newName: "OwnerName");

            migrationBuilder.RenameColumn(
                name: "EditorId",
                table: "Camp",
                newName: "EditorName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerName",
                table: "Camp",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "EditorName",
                table: "Camp",
                newName: "EditorId");

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
    }
}
