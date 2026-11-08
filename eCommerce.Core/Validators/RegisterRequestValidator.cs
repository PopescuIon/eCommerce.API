using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x =>x.Email)
                .NotEmpty().WithMessage("Email is required;")
                .EmailAddress().WithMessage("Invalid email address format");
          
           RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            RuleFor(x =>x.PersonName)
                .NotEmpty().WithMessage("Password is required;")
                .Length(1,50).WithMessage("Person Name shold have minimum 1 and maxim 50;") ;

            RuleFor(x =>x.Gender)
                .IsInEnum().WithMessage("Invalid gender;")
                .NotEmpty().WithMessage("Password is required;");
        }
    }
}