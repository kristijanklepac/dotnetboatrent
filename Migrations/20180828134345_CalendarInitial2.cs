using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class CalendarInitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SevenDaysPrice",
                table: "BoatCalendars",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "MorningPrice",
                table: "BoatCalendars",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "FullDayPrice",
                table: "BoatCalendars",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "FourteenDaysPrice",
                table: "BoatCalendars",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "AfternoonPrice",
                table: "BoatCalendars",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SevenDaysPrice",
                table: "BoatCalendars",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MorningPrice",
                table: "BoatCalendars",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FullDayPrice",
                table: "BoatCalendars",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FourteenDaysPrice",
                table: "BoatCalendars",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AfternoonPrice",
                table: "BoatCalendars",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }
    }
}
