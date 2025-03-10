using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sofomo.Forecast.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Forecast");

            migrationBuilder.CreateTable(
                name: "Forecast",
                schema: "Forecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecast", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Forecast",
                table: "Forecast",
                columns: new[] { "Id", "Latitude", "Longitude", "Temperature", "Time" },
                values: new object[,]
                {
                    { 1, 37.774900000000002, -122.4194, 18.5, new DateTime(2025, 3, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 40.712800000000001, -74.006, 12.300000000000001, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 51.507399999999997, -0.1278, 0.0, new DateTime(2025, 3, 10, 9, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forecast_Latitude_Longitude_Temperature",
                schema: "Forecast",
                table: "Forecast",
                columns: new[] { "Latitude", "Longitude", "Temperature" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecast",
                schema: "Forecast");
        }
    }
}
