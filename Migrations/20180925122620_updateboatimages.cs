using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class updateboatimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BelongsTo",
                table: "BoatImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitleDe",
                table: "BoatImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitleEn",
                table: "BoatImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitleHr",
                table: "BoatImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitleIt",
                table: "BoatImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BoatImages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BelongsTo",
                table: "BoatImages");

            migrationBuilder.DropColumn(
                name: "ImageTitleDe",
                table: "BoatImages");

            migrationBuilder.DropColumn(
                name: "ImageTitleEn",
                table: "BoatImages");

            migrationBuilder.DropColumn(
                name: "ImageTitleHr",
                table: "BoatImages");

            migrationBuilder.DropColumn(
                name: "ImageTitleIt",
                table: "BoatImages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BoatImages");
        }
    }
}
