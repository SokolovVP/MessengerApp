namespace MessengerApp.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    int? Age,
    string Email,
    string Token);