
using Aluguel_Entregas.API.Feature.Rent.Request;
using FluentValidation;

namespace Aluguel_Entregas.API.Feature.Rent.Validators
{
    public class CreateRentRequestValidator : AbstractValidator<CreateRentRequest>
    {
        public CreateRentRequestValidator()
        {
            RuleFor(m => m.RentalPlans)
                .NotEmpty()
                .WithMessage("RentalPlans can not be empty")
                .IsInEnum()
                .WithMessage("RentalPlans is not a valid option");

            RuleFor(m => m.ExpectedDate)
                 .NotEmpty()
                .WithMessage("ExpectedDate can not be empty")
                .Must(BeValidDateTime)
                .WithMessage("ExpectedDate need to be valid DateTime");
        }

        private bool BeValidDateTime(DateTime date)
        {
            return date != default(DateTime);
        }
    }
}
