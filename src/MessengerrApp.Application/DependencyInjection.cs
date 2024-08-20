using MessengerApp.Application.Services.Authentication.Queries;
using MessengerrApp.Application.Services.Authentication.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MessengerApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
        Services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        Services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        return Services;
    }
}