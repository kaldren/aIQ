using FluentValidation;

namespace aIQ.Application.Features.Settings.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.Request.CurrentPassword).NotEmpty();
        RuleFor(x => x.Request.NewPassword).NotEmpty().MinimumLength(8).MaximumLength(100);
        RuleFor(x => x.Request.ConfirmPassword).NotEmpty().MinimumLength(8).MaximumLength(100);
        RuleFor(RuleFor => RuleFor.Request.ConfirmPassword).Equal(RuleFor => RuleFor.Request.NewPassword).WithMessage("The new password and confirm password do not match.");
    }
}
