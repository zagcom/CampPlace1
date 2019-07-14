using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampplaceTest1.Data.Migrations
{
    public partial class AddCampModelUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEdited",
                table: "Camp",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "AccessibleByCar",
                table: "Camp",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Lake",
                table: "Camp",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mountains",
                table: "Camp",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PoviatFireBrigade",
                table: "Camp",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "River",
                table: "Camp",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sanel",
                table: "Camp",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeCreated",
                table: "Camp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessibleByCar",
                table: "Camp");

            migrationBuilder.DropColumn(
                name: "Lake",
                table: "Camp");

            migrationBuilder.DropColumn(
                name: "Mountains",
                table: "Camp");

            migrationBuilder.DropColumn(
                name: "PoviatFireBrigade",
                table: "Camp");

            migrationBuilder.DropColumn(
                name: "River",
                table: "Camp");

            migrationBuilder.DropColumn(
                name: "Sanel",
                table: "Camp");

            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "Camp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEdited",
                table: "Camp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
