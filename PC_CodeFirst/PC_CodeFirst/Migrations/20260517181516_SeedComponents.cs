using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PC_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class SeedComponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturersId", "ComponentTypesId", "Description", "Name" },
                values: new object[,]
                {
                    { "INT-I7-12K", 1, 1, "High performance desktop processor.", "Intel Core i7-12700K" },
                    { "MSI-D5-32G", 3, 3, "Ultra-fast 6000MHz RAM kit.", "MSI Spatium DDR5 32GB" },
                    { "NVD-RTX407", 2, 2, "Next-gen gaming graphics card.", "NVIDIA GeForce RTX 4070" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "INT-I7-12K");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "MSI-D5-32G");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "NVD-RTX407");
        }
    }
}
