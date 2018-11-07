using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class CalendarInitial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalendarBoatId",
                table: "BoatCalendars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BoatCalendars_CalendarBoatId",
                table: "BoatCalendars",
                column: "CalendarBoatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoatCalendars_Boats_CalendarBoatId",
                table: "BoatCalendars",
                column: "CalendarBoatId",
                principalTable: "Boats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatCalendars_Boats_CalendarBoatId",
                table: "BoatCalendars");

            migrationBuilder.DropIndex(
                name: "IX_BoatCalendars_CalendarBoatId",
                table: "BoatCalendars");

            migrationBuilder.DropColumn(
                name: "CalendarBoatId",
                table: "BoatCalendars");
        }
    }
}
