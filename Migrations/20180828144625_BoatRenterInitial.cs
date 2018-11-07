using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class BoatRenterInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleCalendarId",
                table: "Boats",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoatRenters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    VatId = table.Column<string>(nullable: true),
                    HaveBoatLicense = table.Column<bool>(nullable: false),
                    BoatLicenseInfo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatRenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceDescription = table.Column<string>(nullable: true),
                    InvoiceBoatRenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_BoatRenters_InvoiceBoatRenterId",
                        column: x => x.InvoiceBoatRenterId,
                        principalTable: "BoatRenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProformaInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProformaInvoiceDescription = table.Column<string>(nullable: true),
                    ProformaInvoiceBoatRenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProformaInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProformaInvoices_BoatRenters_ProformaInvoiceBoatRenterId",
                        column: x => x.ProformaInvoiceBoatRenterId,
                        principalTable: "BoatRenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceBoatRenterId",
                table: "Invoices",
                column: "InvoiceBoatRenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoices_ProformaInvoiceBoatRenterId",
                table: "ProformaInvoices",
                column: "ProformaInvoiceBoatRenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProformaInvoices");

            migrationBuilder.DropTable(
                name: "BoatRenters");

            migrationBuilder.DropColumn(
                name: "GoogleCalendarId",
                table: "Boats");
        }
    }
}
