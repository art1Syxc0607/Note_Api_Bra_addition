//// BusinessLogic/Services/JwtService.cs
//using DataAccess;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//public class JwtService
//{
//    private readonly IConfiguration _configuration;

//    public string GenerateToken(Person person)
//    {
//        var claims = new List<Claim>
//        {
//            new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()),
//            new Claim(ClaimTypes.Email, person.Email),
//            new Claim(ClaimTypes.Name, person.Email), // или person.Username
//            new Claim("userId", person.Id.ToString())
//        };

//        var key = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
//        );
//        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//        var token = new JwtSecurityToken(
//            issuer: _configuration["Jwt:Issuer"],
//            audience: _configuration["Jwt:Audience"],
//            claims: claims,
//            expires: DateTime.UtcNow.AddHours(3), // срок действия
//            signingCredentials: credentials
//        );

//        return new JwtSecurityTokenHandler().WriteToken(token);
//    }
//}