using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(10).WithMessage("max length is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(10).WithMessage("{PropertyName} length is 10");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(10).WithMessage("max length is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(10).WithMessage("{PropertyName} length is 10");
        }
    }
}
