using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace aIQ.Application.Features.Settings.ChangePassword;

public static class ChangePasswordEndpoint
{
    public static void MapChangePasswordEndpoint(this WebApplication app)
    {
        app.MapPut("/api/settings/change-password", async (ChangePasswordRequest request, ISender sender) =>
        {
            var validationResult = await new ChangePasswordRequestValidator().ValidateAsync(request);

            var result = await sender.Send(new ChangePasswordCommand() { Request = request});

            if (result.IsSuccess == false)
            {
                return Results.BadRequest(result.ValidationErrors);
            }

            return Results.NoContent();
        });
    }
}
