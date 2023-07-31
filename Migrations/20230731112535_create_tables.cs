using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObaidaAl_NaheelTask_001.Migrations
{
    public partial class create_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarNumber);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubstitDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Drivers_SubstitDriverId",
                        column: x => x.SubstitDriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    CarNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => new { x.CarNumber, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarNumber",
                        column: x => x.CarNumber,
                        principalTable: "Cars",
                        principalColumn: "CarNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerName" },
                values: new object[,]
                {
                    { new Guid("821f079c-56d7-4622-88cc-32e6f4245b31"), "Customer3" },
                    { new Guid("8c361a5c-47bc-4180-bebf-d632dc1578d0"), "Customer2" },
                    { new Guid("a11746f0-6fd3-423c-bde5-8c5a7fc37682"), "Customer1" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "DriverName", "IsAvailable", "SubstitDriverId" },
                values: new object[,]
                {
                    { new Guid("1ed297d6-4d66-4b04-ab6b-5a4468506044"), "driver2", false, null },
                    { new Guid("457c23e0-52fc-4657-8568-cd98b3b25c84"), "driver1", false, null },
                    { new Guid("6b87a8a7-5622-401b-ac01-91bfca9de089"), "driver3", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_SubstitDriverId",
                table: "Drivers",
                column: "SubstitDriverId",
                unique: true,
                filter: "[SubstitDriverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_DriverId",
                table: "Rentals",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
