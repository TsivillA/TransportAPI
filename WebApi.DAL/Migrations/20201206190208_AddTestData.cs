using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.DAL.Migrations
{
    public partial class AddTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "EntityStatus", "LastName", "Name", "PersonalId" },
                values: new object[,]
                {
                    { 1, 0, "Tsivilashvili", "Nika", "15921850518" },
                    { 2, 0, "Tsivilashvili", "Luka", "23421850518" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Color", "EntityStatus", "FuelTypeId", "ImageName", "MakeEn", "MakeGe", "ManufactureDate", "ModelEn", "ModelGe", "RegistrationPlate", "Vin" },
                values: new object[,]
                {
                    { 1, 4, 0, 2, null, "Nissan", "ნისანი", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTR", "ჯიტიერი", "NI-777-KA", "AB123JVLA179ACA0R" },
                    { 2, 3, 0, 3, null, "Opel", "ოპელ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vectra", "ვექტრა", "LU-001-KA", "mn323JVLA179ACA0R" }
                });

            migrationBuilder.InsertData(
                table: "VehicleOwner",
                columns: new[] { "Id", "EntityStatus", "OwnerId", "VehicleId" },
                values: new object[] { 1, 0, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleOwner",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
