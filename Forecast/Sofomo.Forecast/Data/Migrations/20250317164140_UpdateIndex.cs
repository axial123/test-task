using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofomo.Forecast.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Forecast_Latitude_Longitude_Temperature",
                schema: "Forecast",
                table: "Forecast");

            migrationBuilder.CreateIndex(
                name: "IX_Forecast_Latitude_Longitude_Time",
                schema: "Forecast",
                table: "Forecast",
                columns: new[] { "Latitude", "Longitude", "Time" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Forecast_Latitude_Longitude_Time",
                schema: "Forecast",
                table: "Forecast");

            migrationBuilder.CreateIndex(
                name: "IX_Forecast_Latitude_Longitude_Temperature",
                schema: "Forecast",
                table: "Forecast",
                columns: new[] { "Latitude", "Longitude", "Temperature" },
                unique: true);
        }
    }
}
