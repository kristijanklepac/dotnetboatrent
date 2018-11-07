using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class BoatsTableImageswithmany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoatImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageAltHr = table.Column<string>(nullable: true),
                    ImageAltDe = table.Column<string>(nullable: true),
                    ImageAltEn = table.Column<string>(nullable: true),
                    ImageAltIt = table.Column<string>(nullable: true),
                    OrigImage = table.Column<string>(nullable: true),
                    ImageXlUrl = table.Column<string>(nullable: true),
                    ImageMdUrl = table.Column<string>(nullable: true),
                    ImageSmUrl = table.Column<string>(nullable: true),
                    ImageLgUrl = table.Column<string>(nullable: true),
                    ImageCaptionHr = table.Column<string>(nullable: true),
                    ImageCaptionDe = table.Column<string>(nullable: true),
                    ImageCaptionEn = table.Column<string>(nullable: true),
                    ImageCaptionIt = table.Column<string>(nullable: true),
                    Orderx = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrentBoatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoatImages_Boats_CurrentBoatId",
                        column: x => x.CurrentBoatId,
                        principalTable: "Boats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatImages_CurrentBoatId",
                table: "BoatImages",
                column: "CurrentBoatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatImages");
        }
    }
}
