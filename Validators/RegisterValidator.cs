using appflow.DTOs;
using FluentValidation;

namespace appflow.Validators;

public class RegisterValidator : AbstractValidator<RegisterDto>
{

    public RegisterValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotNull().MinimumLength(5);
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("A senha de confirmação não é igual a senha.");
    }
}