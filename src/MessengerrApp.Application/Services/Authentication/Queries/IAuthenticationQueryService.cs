using ErrorOr;

namespace MessengerApp.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string Email, string Password);
}