using BussinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//using BCrypt.Net;

namespace WebApi;

[ApiController]
[Route("login")]
public class PersonController(INoteService noteService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Send_form()
    {
        return new VirtualFileResult("/index.html", "text/html");
    }



    [HttpPost]
    public async Task<IActionResult> Registrl([FromForm] string? email_login, [FromForm] string? password)
    {

        await noteService.Login(email_login, password);

        string result = JwtService.GenerateToken(email_login);

        return Ok(new
        {
            token = result,
            expiresIn = 3600 // секунд
        });

    }

}



public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}