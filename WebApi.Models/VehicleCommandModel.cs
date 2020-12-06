using FluentValidation;
using System;
using WebApi.Common.Enums;

namespace WebApi.Models
{
    public class VehicleCommandModel
    {
        public string MakeGe { get; set; }
        public string MakeEn { get; set; }
        public string ModelGe { get; set; }
        public string ModelEn { get; set; }
        public string Vin { get; set; }
        public string RegistrationPlate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public Color Color { get; set; }
        public int FuelTypeId { get; set; }
    }

    public class VehicleCommandModelValidator : AbstractValidator<VehicleCommandModel>
    {
        public VehicleCommandModelValidator()
        {
            RuleFor(x => x.MakeGe).NotEmpty().WithMessage("This is a required field")
                .Length(1, 30).WithMessage("The length must be between ({MinLength}-{MaxLength})")
                .Matches(@"^[ა-ჰ]+$").WithMessage("The language used should be Georgian");

            RuleFor(x => x.MakeEn).NotEmpty().WithMessage("This is a required field")
                .Length(1, 30).WithMessage("The length must be between ({MinLength}-{MaxLength})")
                .Matches(@"^[A-z]+$").WithMessage("The language used should be English");

            RuleFor(x => x.MakeGe).NotEmpty().WithMessage("This is a required field")
                .Length(1, 30).WithMessage("The length must be between ({MinLength}-{MaxLength})")
                .Matches(@"^[ა-ჰ]+$").WithMessage("The language used should be Georgian");

            RuleFor(x => x.MakeEn).NotEmpty().WithMessage("This is a required field")
                .Length(1, 30).WithMessage("The length must be between ({MinLength}-{MaxLength})")
                .Matches(@"^[A-z]+$").WithMessage("The language used should be English");

            RuleFor(x => x.Vin).NotEmpty().WithMessage("This is a required field")
                .Length(17).WithMessage("The length must be 17 characters)");

            RuleFor(x => x.RegistrationPlate).NotEmpty().WithMessage("This is a required field")
                .Length(9).WithMessage("The length must be 9 characters)")
                .Matches(@"^[A-Z]{2}-[0-9]{3}-[A-Z]{2}$").WithMessage("Incorrect format");

            RuleFor(x => x.Color).NotEmpty().WithMessage("This is a required field")
                .IsInEnum().WithMessage("This color doesnt exist");
        }
    }
}
