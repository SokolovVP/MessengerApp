using MessengerApp.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MessengerApp.Domain.Models;
using MessengerApp.Domain.Common.Errors;
using MessengerApp.Application.Common.Interfaces.Authentication;

namespace MessengerApp.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public ErrorOr<AuthenticationResult> Login(string Email, string Password)
    {
        if (_userRepository.GetUserByEmail(Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}