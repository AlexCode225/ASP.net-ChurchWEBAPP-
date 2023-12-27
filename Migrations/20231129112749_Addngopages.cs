using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock_system.Migrations
{
    /// <inheritdoc />
    public partial class Addngopages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prayerwalls",
                columns: table => new
                {
                    PrayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerTopic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScriptureRefs = table.Column<bool>(type: "bit", nullable: false),
                    DayRequested = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayerwalls", x => x.PrayerId);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer", 
                columns: table => new
                {
                    VolunteerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolunteerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.VolunteerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prayerwalls");

            migrationBuilder.DropTable(
                name: "Volunteer");
        }
    }
}
