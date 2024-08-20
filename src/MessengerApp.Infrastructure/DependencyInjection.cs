using MessengerApp.Application.Common.Interfaces.Authentication;
using MessengerApp.Application.Common.Interfaces.Persistence;
using MessengerApp.Application.Common.Interfaces.Services;
using MessengerApp.Infrastructure.Authentication;
using MessengerApp.Infrastructure.Persistence;
using MessengerApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MessengerApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection Services, ConfigurationManager Configuration)
    {
        Services.Configure<JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));
        Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        Services.AddScoped<IUserRepository, UserRepository>();

        return Services;
    }
}