using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class BoatsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BoatName = table.Column<string>(nullable: false),
                    DescriptionHr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionIt = table.Column<string>(nullable: true),
                    ContentHr = table.Column<string>(nullable: true),
                    ContentDe = table.Column<string>(nullable: true),
                    ContentEn = table.Column<string>(nullable: true),
                    ContentIt = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Motor = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    NrPersons = table.Column<int>(nullable: false),
                    Width = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    Water = table.Column<string>(nullable: true),
                    Fuel = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boats");
        }
    }
}
