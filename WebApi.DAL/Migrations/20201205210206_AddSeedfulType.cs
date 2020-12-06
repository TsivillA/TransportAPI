using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.DAL.Migrations
{
    public partial class AddSeedfulType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "EntityStatus", "Name" },
                values: new object[] { 1, 0, "Hybrid" });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "EntityStatus", "Name" },
                values: new object[] { 2, 0, "Gasoline" });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "EntityStatus", "Name" },
                values: new object[] { 3, 0, "Diesel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
