using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class CalendarInitial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoatCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookDate = table.Column<DateTime>(type: "Date", nullable: false),
                    FullDayPrice = table.Column<decimal>(nullable: false),
                    MorningPrice = table.Column<decimal>(nullable: false),
                    AfternoonPrice = table.Column<decimal>(nullable: false),
                    SevenDaysPrice = table.Column<decimal>(nullable: false),
                    FourteenDaysPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatCalendars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatCalendars");
        }
    }
}
