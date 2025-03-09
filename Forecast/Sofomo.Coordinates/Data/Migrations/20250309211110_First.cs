using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sofomo.Coordinates.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Coordinates");

            migrationBuilder.CreateTable(
                name: "Coordinates",
                schema: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Coordinates",
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { "51.097817.032707", 51.097799999999999, 17.032706999999998 },
                    { "51.107550417.0690172", 51.107550400000001, 17.069017200000001 },
                    { "51.117264217.0215266", 51.117264200000001, 17.021526600000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinates",
                schema: "Coordinates");
        }
    }
}
