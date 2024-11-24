using Ardalis.Result;
using MediatR;

namespace aIQ.Application.Features.Settings.ChangePassword;

public sealed record ChangePasswordCommand : IRequest<Result<ChangePasswordResponse>>
{
    public required ChangePasswordRequest Request { get; init; }
}