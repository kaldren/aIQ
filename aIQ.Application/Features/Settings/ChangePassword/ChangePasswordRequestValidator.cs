using FluentValidation;

namespace aIQ.Application.Features.Settings.ChangePassword;

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty()
            .WithMessage("Current password cannot be empty.");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(100);

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(100);

        RuleFor(RuleFor => RuleFor.ConfirmPassword)
            .Equal(RuleFor => RuleFor.NewPassword)
            .WithMessage("The new password and confirm password do not match.");
    }
}
