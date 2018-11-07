using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapptesy.Migrations
{
    public partial class ProInvRowsAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ProformaInvoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "InvoiceRows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookDate = table.Column<DateTime>(type: "Date", nullable: false),
                    FullDayPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MorningPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AfternoonPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SevenDaysPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FourteenDaysPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CalendarBoatId = table.Column<int>(nullable: false),
                    CurrentInvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceRows_Invoices_CurrentInvoiceId",
                        column: x => x.CurrentInvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProformaInvoiceRows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookDate = table.Column<DateTime>(type: "Date", nullable: false),
                    FullDayPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MorningPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AfternoonPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SevenDaysPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FourteenDaysPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CalendarBoatId = table.Column<int>(nullable: false),
                    CurrentProformaInvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProformaInvoiceRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProformaInvoiceRows_ProformaInvoices_CurrentProformaInvoiceId",
                        column: x => x.CurrentProformaInvoiceId,
                        principalTable: "ProformaInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceRows_CurrentInvoiceId",
                table: "InvoiceRows",
                column: "CurrentInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceRows_CurrentProformaInvoiceId",
                table: "ProformaInvoiceRows",
                column: "CurrentProformaInvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceRows");

            migrationBuilder.DropTable(
                name: "ProformaInvoiceRows");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ProformaInvoices");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Invoices");
        }
    }
}
