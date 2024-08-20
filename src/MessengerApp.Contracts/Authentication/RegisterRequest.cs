namespace MessengerApp.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    int Age,
    string Email,
    string Password);