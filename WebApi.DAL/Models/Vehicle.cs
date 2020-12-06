using System;
using System.Collections.Generic;
using WebApi.Common.Enums;

namespace WebApi.DAL.Models
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public string MakeGe { get; set; }
        public string MakeEn { get; set; }
        public string ModelGe { get; set; }
        public string ModelEn { get; set; }
        public string Vin { get; set; }
        public string RegistrationPlate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public Color Color { get; set; }
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        public ICollection<VehicleOwner> VehicleOwner { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public string ImageName { get; set; }
    }
}
