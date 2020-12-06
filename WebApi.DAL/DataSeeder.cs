using Microsoft.EntityFrameworkCore;
using WebApi.Common.Enums;
using WebApi.DAL.Models;

namespace WebApi.DAL
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<FuelType>().HasData(
                new FuelType
                {
                    Id = 1,
                    Name = "Hybrid"
                },

                new FuelType
                {
                    Id = 2,
                    Name = "Gasoline"
                },

                new FuelType
                {
                    Id = 3,
                    Name = "Diesel"
                }
                );

            builder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    MakeGe = "ნისანი",
                    MakeEn = "Nissan",
                    ModelGe = "ჯიტიერი",
                    ModelEn = "GTR",
                    Vin = "AB123JVLA179ACA0R",
                    RegistrationPlate = "NI-777-KA",
                    Color = Color.Black,
                    FuelTypeId = 2,
                }); ;
            builder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 2,
                    MakeGe = "ოპელ",
                    MakeEn = "Opel",
                    ModelGe = "ვექტრა",
                    ModelEn = "Vectra",
                    Vin = "mn323JVLA179ACA0R",
                    RegistrationPlate = "LU-001-KA",
                    Color = Color.Blue,
                    FuelTypeId = 3,
                }); ;

            builder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = 1,
                    Name = "Nika",
                    LastName = "Tsivilashvili",
                    PersonalId = "15921850518"
                });

            builder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = 2,
                    Name = "Luka",
                    LastName = "Tsivilashvili",
                    PersonalId = "23421850518"
                });

            builder.Entity<VehicleOwner>().HasData(
                new VehicleOwner
                {
                    Id = 1,
                    VehicleId = 1,
                    OwnerId = 1
                });
        }
    }
}
