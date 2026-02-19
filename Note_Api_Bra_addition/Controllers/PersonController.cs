using BusinessLogic.Services;
using BussinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Note_Api_Bra.DTO.Auth;
using Note_Api_Bra_addition.DTO.Auth;
using System.Text;
//using BCrypt.Net;

namespace Note_Api_Bra_addition;

[ApiController]
//[Route("login")]
public class PersonController(IAuthService authService) : ControllerBase
{
    //[HttpGet("login")]
    //public async Task<IActionResult> Send_form()
    //{
    //    return new VirtualFileResult("/index.html", "text/html");
    //}



    //[HttpPost]
    //public async Task<IActionResult> Registrl([FromForm] string? email_login, [FromForm] string? password)
    //{

    //    await noteService.Login(email_login, password);

    //    string result = JwtService.GenerateToken(email_login);

    //    return Ok(new
    //    {
    //        token = result,
    //        expiresIn = 3600 // секунд
    //    });

    //}

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        // loginDto.EmailLogin - одна переменная для email/логина
        // loginDto.Password
        var result = await authService.LoginAsync(loginDto.EmailLogin, loginDto.Password);

        if (!result.Success)
        {
            // Для логина обычно 401 Unauthorized
            return Unauthorized(new { error = result.Error });
        }

        var response = new AuthResponseDto
        {
            Token = result.Token,
            UserId = result.UserId,
            EmailLogin = result.Email_login,
            ExpiresIn = 3600
        };

        return Ok(response);
    }

    [HttpPost("reg")]
    public async Task<IActionResult> Reg([FromBody] LoginDto loginDto)
    {
        // loginDto.EmailLogin - одна переменная для email/логина
        // loginDto.Password
        var result = await authService.RegisterAsync(loginDto.EmailLogin, loginDto.Password);

        // Проверяем флаг успеха
        if (!result.Success)
        {
            // Возвращаем 400 Bad Request с описанием ошибки
            return BadRequest(new { error = result.Error });
        }

        // Успех - возвращаем 200 OK с данными
        var response = new AuthResponseDto
        {
            Token = result.Token,
            UserId = result.UserId,
            EmailLogin = result.Email_login,
            ExpiresIn = 3600
        };

        return Ok(response);
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