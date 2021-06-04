using Common.DTO;
using FluentValidation;


namespace Common.Validators
{
    public class DeveloperDTOValidator : AbstractValidator<DeveloperDTO>
    {
        public DeveloperDTOValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email can not be empty")
                .EmailAddress().WithMessage("Please, check your email address");

            RuleFor(u => u.Age)
                .LessThan(100)
                .GreaterThan(18).WithMessage("Age must be between 18 and 100");

            RuleFor(u => u.Description)
                .MinimumLength(2).WithMessage("Description must be more than 2 symbols.")
                .MaximumLength(160).WithMessage("Lenght of description must be less than 160 symbols.");

            RuleFor(u => u.DateOfBirthday)
                .NotEmpty().WithMessage($"Field DateOfBirthday is required")
                .LessThan(u => u.DateOfStartWorking).WithMessage("Date of Birthday must be less than Date of Start Working");

            RuleFor(u => u.DateOfStartWorking)
                .NotEmpty().WithMessage("Field DateOfStartWorking is required");

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .MaximumLength(50).WithMessage("Name can not be more that 50 symbols.")
                .MinimumLength(1).WithMessage("Name can not be less than 1 symbols.");
               
        }
    }
}
