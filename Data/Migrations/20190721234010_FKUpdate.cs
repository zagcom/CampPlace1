using Microsoft.EntityFrameworkCore.Migrations;

namespace CampplaceTest1.Data.Migrations
{
    public partial class FKUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Camp_CampId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Camp_CampId",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "CampId",
                table: "Reservation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CampId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Camp_CampId",
                table: "Comment",
                column: "CampId",
                principalTable: "Camp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Camp_CampId",
                table: "Reservation",
                column: "CampId",
                principalTable: "Camp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Camp_CampId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Camp_CampId",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "CampId",
                table: "Reservation",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CampId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Camp_CampId",
                table: "Comment",
                column: "CampId",
                principalTable: "Camp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Camp_CampId",
                table: "Reservation",
                column: "CampId",
                principalTable: "Camp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
