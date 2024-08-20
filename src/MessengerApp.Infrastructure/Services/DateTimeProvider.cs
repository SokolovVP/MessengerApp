using MessengerApp.Application.Common.Interfaces.Services;

namespace MessengerApp.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}