using WebApi.Common.Enums;

namespace WebApi.Models
{
    public class VehicleFilterModel
    {
        public string MakeGe { get; set; }
        public string MakeEn { get; set; }
        public string ModelGe { get; set; }
        public string ModelEn { get; set; }
        public string Vin { get; set; }
        public string RegistrationPlate { get; set; }
        public Color? Color { get; set; }
        public int? FuelTypeId { get; set; }
    }
}
