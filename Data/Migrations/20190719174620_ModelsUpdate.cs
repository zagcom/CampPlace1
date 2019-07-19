using Microsoft.EntityFrameworkCore.Migrations;

namespace CampplaceTest1.Data.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comment",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Verified",
                table: "Camp",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Edited",
                table: "Camp",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Edited",
                table: "Camp");

            migrationBuilder.AlterColumn<int>(
                name: "Verified",
                table: "Camp",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
