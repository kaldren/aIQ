using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using MediatR;

namespace aIQ.Application.Features.Settings.ChangePassword;

public sealed record ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result<ChangePasswordResponse>>
{
    private readonly IValidator<ChangePasswordCommand> _validator;

    public ChangePasswordCommandHandler(IValidator<ChangePasswordCommand> validator)
    {
        _validator = validator;
    }

    public async Task<Result<ChangePasswordResponse>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return Result.Invalid(validationResult.AsErrors());
        }

        return Result<ChangePasswordResponse>.Success(new ChangePasswordResponse());
    }
}
