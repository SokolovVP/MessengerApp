using MessengerApp.Application.Common.Interfaces.Authentication;
using MessengerApp.Application.Common.Interfaces.Services;
using MessengerApp.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MessengerApp.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(User user)
    {
        string secret_key = "super_super_secret_secret_keykey";

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret_key)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "Vadim Sokolov",
            audience: "MessengerApp",
            expires: _dateTimeProvider.Now.AddMinutes(1),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}