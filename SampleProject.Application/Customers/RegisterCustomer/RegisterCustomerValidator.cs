using FluentValidation;

namespace SampleProject.Application.Customers.RegisterCustomer;

public class RegisterCustomerValidator : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(5).WithMessage("Email must  greater than 5 char");
        RuleFor(x => x.Name).NotEmpty().MaximumLength(5).WithMessage("Name must  greater than 5 char");

    }
}