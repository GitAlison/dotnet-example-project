using appflow.DTOs;
using FluentValidation;


namespace appflow.Validators;

public class LoginValidator : AbstractValidator<LoginDto> 
{
  public LoginValidator() 
  {
    RuleFor(x => x.Email).NotEmpty().EmailAddress();
    RuleFor(x => x.Password).NotNull();
  }
}