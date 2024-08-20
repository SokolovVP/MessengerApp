using MessengerApp.Application.Common.Interfaces.Authentication;
using MessengerApp.Application.Common.Interfaces.Persistence;
using MessengerApp.Domain.Models;
using MessengerApp.Domain.Common.Errors;
using ErrorOr;
using MessengerApp.Application.Services.Authentication;

namespace MessengerrApp.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, int Age, string Email, string Password)
    {
        if (_userRepository.GetUserByEmail(Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Age = Age,
            Email = Email,
            Password = Password
        };

        _userRepository.Add(user);

        string Token = _jwtTokenGenerator.GenerateToken(user);
        var response = new AuthenticationResult(user, Token);

        return response;
    } 
}