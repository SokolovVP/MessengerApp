using MessengerApp.Domain.Models;

namespace MessengerApp.Application.Services.Authentication;

public record AuthenticationResult(User user, string Token);