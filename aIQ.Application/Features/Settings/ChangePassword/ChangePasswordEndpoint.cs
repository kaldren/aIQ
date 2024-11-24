using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace aIQ.Application.Features.Settings.ChangePassword;

public static class ChangePasswordEndpoint
{
    public static void MapChangePasswordEndpoint(this WebApplication app)
    {
        app.MapPut("/api/settings/change-password", async (ChangePasswordRequest request) =>
        {
            return Results.Ok($"Your old password is {request.CurrentPassword}, your new password is {request.NewPassword}, and your confirmation password is {request.ConfirmPassword}");
        });
    }
}
