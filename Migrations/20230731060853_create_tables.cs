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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    substitDriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Drivers_substitDriverId",
                        column: x => x.substitDriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCars",
                columns: table => new
                {
                    CarNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCars", x => new { x.CarNumber, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerCars_Cars_CarNumber",
                        column: x => x.CarNumber,
                        principalTable: "Cars",
                        principalColumn: "CarNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCars_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverCars",
                columns: table => new
                {
                    CarNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverCars", x => new { x.CarNumber, x.DriverId });
                    table.ForeignKey(
                        name: "FK_DriverCars_Cars_CarNumber",
                        column: x => x.CarNumber,
                        principalTable: "Cars",
                        principalColumn: "CarNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverCars_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerName" },
                values: new object[,]
                {
                    { 1, "Customer1" },
                    { 2, "Customer2" },
                    { 3, "Customer3" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "DriverName", "substitDriverId" },
                values: new object[,]
                {
                    { 1, "driver1", null },
                    { 2, "driver2", null },
                    { 3, "driver3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCars_CustomerId",
                table: "CustomerCars",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverCars_DriverId",
                table: "DriverCars",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_substitDriverId",
                table: "Drivers",
                column: "substitDriverId",
                unique: true,
                filter: "[substitDriverId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCars");

            migrationBuilder.DropTable(
                name: "DriverCars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
