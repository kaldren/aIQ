using aIQ.Application.Features.Settings.ChangePassword;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace aIQ.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssemblyContaining<ChangePasswordCommandValidator>();

        return services;
    }
}
