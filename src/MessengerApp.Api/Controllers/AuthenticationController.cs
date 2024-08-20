using MessengerApp.Contracts.Authentication;
using MessengerApp.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MessengerApp.Domain.Common.Errors;
using MessengerrApp.Application.Services.Authentication.Commands;
using MessengerApp.Application.Services.Authentication.Queries;

namespace MessengerApp.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(
        IAuthenticationCommandService authenticationCommandService, 
        IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authenticationResult = _authenticationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Age,
            request.Email,
            request.Password);

        return authenticationResult.Match(
                authenticationResult => Ok(MapAuthenticationResult(authenticationResult)),
                errors => Problem(errors));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authenticationResult = _authenticationQueryService.Login(
            request.Email,
            request.Password);

        if (authenticationResult.IsError && authenticationResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized, 
                title: authenticationResult.FirstError.Description);
        }

        return authenticationResult.Match(
            authenticationResult => Ok(MapAuthenticationResult(authenticationResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthenticationResult (AuthenticationResult authenticationResult)
    {
        return new AuthenticationResponse(
            authenticationResult.user.Id,
            authenticationResult.user.FirstName,
            authenticationResult.user.LastName,
            authenticationResult.user.Age,
            authenticationResult.user.Email,
            authenticationResult.Token);
    }
}