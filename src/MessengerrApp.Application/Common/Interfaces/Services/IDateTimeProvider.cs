﻿namespace MessengerApp.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    public DateTime Now { get; }
}