using FluentValidation;

namespace WebApi.Models
{
    public class OwnerCommandModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
    }

    public class OwnerCommandModelValidator : AbstractValidator<OwnerCommandModel>
    {
        public OwnerCommandModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This is a required field")
                .Length(3, 30).WithMessage("The length must be between ({MinLength}-{MaxLength})");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("This is a required field")
                .Length(3, 50).WithMessage("The length must be between ({MinLength}-{MaxLength})");

            RuleFor(x => x.PersonalId).NotEmpty().WithMessage("This is a required field")
                .Length(11).WithMessage("The length must be 11");
        }
    }
}
