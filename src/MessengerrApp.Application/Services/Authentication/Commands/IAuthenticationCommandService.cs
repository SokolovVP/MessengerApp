using ErrorOr;
using MessengerApp.Application.Services.Authentication;

namespace MessengerrApp.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, int Age, string Email, string Password);
}