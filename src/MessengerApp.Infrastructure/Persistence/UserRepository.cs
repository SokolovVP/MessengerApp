﻿using MessengerApp.Application.Common.Interfaces.Persistence;
using MessengerApp.Domain.Models;

namespace MessengerApp.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByEmail (string email)
    {
        return _users.SingleOrDefault<User>(u => u.Email == email);
    }

    public void Add (User user)
    {
        _users.Add(user);
    }
}