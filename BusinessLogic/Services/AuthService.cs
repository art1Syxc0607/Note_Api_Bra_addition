using DataAccess.Repositories;
using DataAccess.Entities;
using BusinessLogic.Services.Jwt;

namespace BusinessLogic.Services;


public class AuthService : IAuthService
{
    private readonly IPersonRepository _personRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IPersonRepository personRepository, IJwtService jwtService)
    {
        _personRepository = personRepository;
        _jwtService = jwtService;
    }

    public async Task<AuthResult> RegisterAsync(string emailLogin, string password)
    {
        // 1. Проверяем, есть ли уже такой пользователь
        var existingPerson = await _personRepository.GetByEmailLoginAsync(emailLogin);
        if (existingPerson != null)
            return AuthResult.ErrorResult("Пользователь уже существует");

        // 2. Хешируем пароль
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        // 3. Создаем пользователя
        var person = new Person
        {
            Email_login = emailLogin,
            Password_hash = passwordHash,
            Created = DateTime.UtcNow
        };

        await _personRepository.CreateAsync(person);

        // 4. Генерируем токен
        var token = _jwtService.GenerateToken(person.Email_login, person.Id);

        return AuthResult.SuccessResult(token, person.Id, person.Email_login);
    }

    public async Task<AuthResult> LoginAsync(string emailLogin, string password)
    {
        // 1. Ищем пользователя
        var person = await _personRepository.GetByEmailLoginAsync(emailLogin);
        if (person == null)
            return AuthResult.ErrorResult("Неверный логин или пароль");

        // 2. Проверяем пароль
        bool isValid = BCrypt.Net.BCrypt.Verify(password, person.Password_hash);
        if (!isValid)
            return AuthResult.ErrorResult("Неверный логин или пароль");

        // 3. Генерируем токен
        var token = _jwtService.GenerateToken(person.Email_login, person.Id);

        return AuthResult.SuccessResult(token, person.Id, person.Email_login);
    }

    //AuthResult специальная "прокладка" для отправки JSON

}