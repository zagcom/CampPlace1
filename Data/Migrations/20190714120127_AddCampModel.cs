using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampplaceTest1.Data.Migrations
{
    public partial class AddCampModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voivodeship = table.Column<int>(nullable: false),
                    Community = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SummerCamp = table.Column<bool>(nullable: false),
                    WinterCamp = table.Column<bool>(nullable: false),
                    Bivouac = table.Column<bool>(nullable: false),
                    Scouts = table.Column<bool>(nullable: false),
                    WolfCubs = table.Column<bool>(nullable: false),
                    Buildings = table.Column<bool>(nullable: false),
                    Toilet = table.Column<bool>(nullable: false),
                    Kitchen = table.Column<bool>(nullable: false),
                    SleepingInside = table.Column<bool>(nullable: false),
                    MaxPeopleCapacity = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    DistanceFromBuildings = table.Column<string>(nullable: true),
                    NearestHospital = table.Column<string>(nullable: true),
                    NearestFireDepartment = table.Column<string>(nullable: true),
                    NearestPoliceStation = table.Column<string>(nullable: true),
                    NearestMarket = table.Column<string>(nullable: true),
                    ContactPoint = table.Column<string>(nullable: true),
                    EmailToCP = table.Column<string>(nullable: true),
                    PhoneToCP = table.Column<string>(nullable: true),
                    LastEdited = table.Column<DateTime>(nullable: false),
                    EditorId = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camp", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camp");
        }
    }
}
