using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class daystable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProformaInvoiceBoatName",
                table: "ProformaInvoiceRows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceBoatName",
                table: "InvoiceRows",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DaysWithInterest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrentProformaInvoiceRowId = table.Column<int>(nullable: false),
                    MorningLocked = table.Column<bool>(nullable: false),
                    AfternoonLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysWithInterest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysWithInterest_ProformaInvoiceRows_CurrentProformaInvoiceR~",
                        column: x => x.CurrentProformaInvoiceRowId,
                        principalTable: "ProformaInvoiceRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaysWithNoAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrentInvoiceRowId = table.Column<int>(nullable: false),
                    MorningLocked = table.Column<bool>(nullable: false),
                    AfternoonLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysWithNoAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysWithNoAvailability_InvoiceRows_CurrentInvoiceRowId",
                        column: x => x.CurrentInvoiceRowId,
                        principalTable: "InvoiceRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaysWithInterest_CurrentProformaInvoiceRowId",
                table: "DaysWithInterest",
                column: "CurrentProformaInvoiceRowId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaysWithNoAvailability_CurrentInvoiceRowId",
                table: "DaysWithNoAvailability",
                column: "CurrentInvoiceRowId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysWithInterest");

            migrationBuilder.DropTable(
                name: "DaysWithNoAvailability");

            migrationBuilder.DropColumn(
                name: "ProformaInvoiceBoatName",
                table: "ProformaInvoiceRows");

            migrationBuilder.DropColumn(
                name: "InvoiceBoatName",
                table: "InvoiceRows");
        }
    }
}
