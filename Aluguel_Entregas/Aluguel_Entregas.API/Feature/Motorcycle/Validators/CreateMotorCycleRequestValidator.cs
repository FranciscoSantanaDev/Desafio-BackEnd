using Aluguel_Entregas.API.Feature.Motorcycle.Request;
using FluentValidation;

namespace Aluguel_Entregas.API.Feature.Motorcycle.Validators
{
    public class CreateMotorCycleRequestValidator : AbstractValidator<CreateMotorcycleRequest>
    {
        public CreateMotorCycleRequestValidator()
        {
           RuleFor(m =>m.Year)
                .NotEmpty()
                .WithMessage("Year can not be empty")
                .GreaterThan(2000)
                .WithMessage("Year must be greater than 2000");

            RuleFor(m => m.Model)
                .NotEmpty()
                .WithMessage("Model can not be empty")
                .Length(1, 100);

            RuleFor(m => m.Plate)
                .NotEmpty()
                .WithMessage("Plate can not be empty")
                .Length(7).WithMessage("The sign must have 7 characters")
                .Matches(@"^[A-Za-z]{3}\d{1}[A-Za-z0-9]{1}\d{2}$");
        }
    }
}
