using aIQ.Domain.Users;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using MediatR;

namespace aIQ.Application.Features.Settings.ChangePassword;

public sealed record ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
{
    private readonly IValidator<ChangePasswordCommand> _validator;

    public ChangePasswordCommandHandler(IValidator<ChangePasswordCommand> validator)
    {
        _validator = validator;
    }

    public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return Result.Invalid(validationResult.AsErrors());
        }

        var user = new User();
        user.ChangePassword(request.Request.NewPassword);

        return Result.NoContent();
    }
}
