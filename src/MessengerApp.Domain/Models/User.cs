namespace MessengerApp.Domain.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int? Age { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}