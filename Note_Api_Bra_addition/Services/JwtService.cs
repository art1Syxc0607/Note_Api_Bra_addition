using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;


namespace WebApi;

public static class JwtService
{
    public static string GenerateToken(string email_login)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, email_login),
            new Claim(ClaimTypes.Name, email_login),

        };

        var token = new JwtSecurityToken(
           issuer: AuthOptions.ISSUER,
           audience: AuthOptions.AUDIENCE,
           claims: claims,
           expires: DateTime.UtcNow.AddHours(1), // срок действия
           signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));


        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
