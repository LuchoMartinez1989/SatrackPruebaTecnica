using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistense.Migrations
{
    /// <inheritdoc />
    public partial class SetupTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdenticacionCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Lastnames = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuscriptionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSuscription = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuscriptionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDescription = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MonthDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePurchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSuscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuscriptionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuscriptionPrice = table.Column<double>(type: "float", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    SuscriptionTypeId = table.Column<int>(type: "int", nullable: false),
                    TypePurchaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSuscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSuscription_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSuscription_SuscriptionTypes_SuscriptionTypeId",
                        column: x => x.SuscriptionTypeId,
                        principalTable: "SuscriptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSuscription_TypePurchases_TypePurchaseId",
                        column: x => x.TypePurchaseId,
                        principalTable: "TypePurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSuscription_IdCustomer",
                table: "CustomerSuscription",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSuscription_SuscriptionTypeId",
                table: "CustomerSuscription",
                column: "SuscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSuscription_TypePurchaseId",
                table: "CustomerSuscription",
                column: "TypePurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSuscription");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SuscriptionTypes");

            migrationBuilder.DropTable(
                name: "TypePurchases");
        }
    }
}
