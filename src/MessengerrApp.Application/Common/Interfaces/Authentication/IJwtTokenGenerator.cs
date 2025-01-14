﻿using MessengerApp.Domain.Models;

namespace MessengerApp.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    public string GenerateToken(User user);
}