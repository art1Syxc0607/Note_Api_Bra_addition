namespace BusinessLogic.Services
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(string emailLogin, string password);
        Task<AuthResult> LoginAsync(string emailLogin, string password);
    }
}