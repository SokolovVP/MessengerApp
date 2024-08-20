using MessengerApp.Domain.Models;

namespace MessengerApp.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}