using Aluguel_Entregas.API.Feature.Courier.Request;
using Aluguel_Entregas.API.Feature.Motorcycle.Request;
using FluentValidation;

namespace Aluguel_Entregas.API.Feature.Motorcycle.Validators
{
    public class CreateCourierRequestValidator : AbstractValidator<CreateCourierRequest>
    {
        public CreateCourierRequestValidator()
        {
            RuleFor(m => m.Name)
                 .NotEmpty()
                 .WithMessage("Name can not be empty")
                 .NotNull()
                 .WithMessage("Name can not be null");

            RuleFor(m => m.Cnpj)
                .NotEmpty()
                .WithMessage("Cnpj can not be empty")
                .Length(1, 18)
                .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
                .WithMessage("Cnpj is not in the correct format");

            RuleFor(m => m.Birth)
                .NotEmpty()
                .WithMessage("Birth can not be empty")
                .Must(BeValidDateTime)
                .WithMessage("Birth need to be valid DateTime");

            RuleFor(m => m.License)
              .NotEmpty()
              .WithMessage("Name can not be empty")
              .NotNull()
              .WithMessage("Name can not be null")
              .Matches(@"^[0-9]{11}$");

            RuleFor(m => m.Username)
                .NotEmpty()
                .WithMessage("Username can not be empty")
                .NotNull()
                .WithMessage("Username can not be null");

            RuleFor(m => m.Password)
                .NotEmpty()
                .WithMessage("Password can not be empty")
                .NotNull()
                .WithMessage("Password can not be null")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number and one special character");

            RuleFor(m => m.LicensesType)
                .NotEmpty()
                .WithMessage("LicensesType can not be empty")
                .IsInEnum()
                .WithMessage("LicensesType is not a valid option");
        }

        private bool BeValidDateTime(DateTime date)
        {
            return date != default(DateTime);
        }
    }
}
